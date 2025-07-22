using AspNetMvcCoreFarmProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Security.Claims;
using System.Text.Json;

namespace AspNetMvcCoreFarmProject.Controllers
{
    public class FarmController : Controller
    {
        private readonly ICustomer dal;
        private readonly IWebHostEnvironment environment;
        private readonly UserManager<IdentityUser> user;

        public FarmController(ICustomer dal, IWebHostEnvironment environment, UserManager<IdentityUser> user)
        {
            this.dal = dal;
            this.environment = environment;
            this.user = user;
        }

        public ViewResult DisplayCustomers()
        {
            return View(dal.Customers_Select());
        }
        public ViewResult DisplayCustomer(int Custid)
        {
            return View(dal.Customer_Select(Custid));
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddCustomer()
        {
            List<string> Breeds = new List<string>{"SEELAVATHI", "KATLA", "BOMBYDAYA", "KORAMENU", "GORAKA" };
            ViewBag.BreedList = new SelectList(Breeds);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer, List<IFormFile> SelectedImages)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("The details you entered does not match the expected patterns. Please enter details again.");
                //return View(customer);
            }
            else if (SelectedImages == null || SelectedImages.Count > 10)
            {
                ModelState.AddModelError("SelectedImages", "Images cannot be null and You can only upload up to 10 images. ");
                return View();
            }
            else
            {
                if (customer.SecondBreed == null)
                {
                    customer.SecondBreed = "---";
                    customer.SB_Price = 0;
                    customer.SB_Pieces = 0;
                }
                if (customer.ThirdBreed == null)
                {
                    customer.ThirdBreed = "---";
                    customer.TB_Price = 0;
                    customer.TB_Pieces = 0;
                }

                List<string> imageurls = new List<string>();

                string UploadsFolder = Path.Combine(environment.WebRootPath, "images");
                if (!Directory.Exists(UploadsFolder))
                {
                    Directory.CreateDirectory(UploadsFolder);
                }

                foreach (var image in SelectedImages)
                {
                    if (image != null && image.Length > 0)
                    {
                        string extension = Path.GetExtension(image.FileName);
                        string Uniquefilename = Guid.NewGuid().ToString() + extension;
                        string filePath = Path.Combine(UploadsFolder, Uniquefilename);

                        var fileStream = new FileStream(filePath, FileMode.Create);
                        await image.CopyToAsync(fileStream);

                        imageurls.Add(Uniquefilename);
                    }
                }
                customer.ImagePath = imageurls;
                customer.Identity_userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.Identity_Email = User.FindFirstValue(ClaimTypes.Email);

                var appuser =await user.GetUserAsync(User);
                customer.Identity_Phone = await user.GetPhoneNumberAsync(appuser);


                dal.Customer_Insert(customer);

                return RedirectToAction("DisplayCustomers");
            }
        }
        [Authorize]
        public ViewResult EditCustomer(int? Custid)
        {
            List<string> Breeds = new List<string> { "SEELAVATHI", "KATLA", "BOMBYDAYA", "KORAMENU", "GORAKA" };
            ViewBag.BreedList = new SelectList(Breeds);

            string LoggedinUserid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (LoggedinUserid == null)
            {
                return View("Login");
            }
            else if(Custid != null)
            {
                return View("EditSinglePost", dal.Customer_Select(Custid.Value));
            }
            else
            {
                return View(dal.EditAllCustomers(LoggedinUserid));
            }
        }

        [Authorize]
        public async Task<IActionResult> UpdateCustomer(Customer customer, List<IFormFile> SelectedImages, string RemovedOldImages)
        {
            // Load breeds, etc.
            List<string> Breeds = new List<string> { "SEELAVATHI", "KATLA", "BOMBYDAYA", "KORAMENU", "GORAKA" };
            ViewBag.BreedList = new SelectList(Breeds);

            var oldCustomerData = dal.Customer_Select(customer.Custid);

            if (oldCustomerData != null)
            {
                customer.ImagePath = oldCustomerData.ImagePath;
            }

            if (!ModelState.IsValid)
            {
                return View("EditSinglePost", customer);
            }

            // Deserialize removed old images list
            List<string> removedOldImagesList = new List<string>();
            if (!string.IsNullOrEmpty(RemovedOldImages))
            {
                removedOldImagesList = JsonSerializer.Deserialize<List<string>>(RemovedOldImages);
            }

            var oldImages = oldCustomerData.ImagePath ?? new List<string>();

            // Keep only images NOT removed
            var keptOldImages = oldImages.Where(img => !removedOldImagesList.Contains(img)).ToList();

            // Delete removed images physically
            string uploadsFolder = Path.Combine(environment.WebRootPath, "images");
            foreach (var removedImage in removedOldImagesList)
            {
                var removedImagePath = Path.Combine(uploadsFolder, removedImage);
                if (System.IO.File.Exists(removedImagePath))
                {
                    System.IO.File.Delete(removedImagePath);
                }
            }

            // Save new uploaded images
            List<string> newUploadedImageUrls = new List<string>();
            if (SelectedImages != null && SelectedImages.Count > 0)
            {
                foreach (var image in SelectedImages)
                {
                    if (image != null && image.Length > 0)
                    {
                        string extension = Path.GetExtension(image.FileName);
                        string uniqueFilename = Guid.NewGuid().ToString() + extension;
                        string filePath = Path.Combine(uploadsFolder, uniqueFilename);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileStream);
                        }

                        newUploadedImageUrls.Add(uniqueFilename);
                    }
                }
            }

            // Combine old kept images and new uploaded images
            customer.ImagePath = keptOldImages.Concat(newUploadedImageUrls).ToList();

            // Your existing code for breed defaults, etc...

            dal.Customer_Update(customer);
            return RedirectToAction("DisplayCustomers");
        }


        [Authorize]
        public RedirectToActionResult DeleteCustomer(int Custid)
        {            
            dal.Customer_Delete(Custid);
            return RedirectToAction("DisplayCustomers");
        }

        public IActionResult DisplayCustomerAds()
        {
            return View();
        }
    }
}
