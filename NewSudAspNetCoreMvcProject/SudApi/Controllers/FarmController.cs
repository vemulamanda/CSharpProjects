using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SudApi.Models;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace SudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        IFarmer dal;
        IWebHostEnvironment environment;

        public FarmController(IFarmer dal, IWebHostEnvironment environment)
        {
            this.dal = dal;
            this.environment = environment;

            Console.WriteLine("FarmController created");
        }

        [HttpGet("test")]
        public HttpResponseMessage ApiTesting()
        {
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [Authorize]
        [HttpGet("loginvalidationcheck")]
        public HttpResponseMessage LoginValidationCheck()
        {
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpGet]
        public List<Farmer> AllFarmerAds()
        {
            return dal.Farmers_Select();
        }

        [HttpGet("district/{district}")]
        public List<Farmer> FarmerAdsByDistrict(string district)
        {
            return dal.Farmer_Select_District(district);
        }

        [HttpGet("getadsusinguserguid/{userguid}")]
        public int GetAdsUsingUserGuid(string userguid)
        {
            return dal.Farmer_Select_By_Guid(userguid);
        }

        [HttpGet("{custid}")]
        public Farmer FarmerAdById(int custid)
        {
            return dal.Farmer_Select(custid);
        }

        [Authorize]
        [HttpPost("insertAd")]
        public async Task<IActionResult> InsertFarmerAd([FromForm] Farmer F, [FromForm] List<IFormFile> CustImages)
        {
            if (!ModelState.IsValid)
            {                
                //return BadRequest("Invalid farmer details.");
                return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }
            if (CustImages == null || CustImages.Count > 10)

                return BadRequest("You can upload up to 10 images.");

            if (F.SecondBreed == null)
            {
                F.SecondBreed = "---";
                F.SB_Price = 0;
                F.SB_Pieces = 0;
            }
            if (F.ThirdBreed == null)
            {
                F.ThirdBreed = "---";
                F.TB_Price = 0;
                F.TB_Pieces = 0;
            }

            var imageUrls = new List<string>();
            var uploadsFolder = Path.Combine(environment.WebRootPath, "images");

            Directory.CreateDirectory(uploadsFolder);

            foreach (var image in CustImages)
            {
                if (image?.Length > 0)
                {
                    var extension = Path.GetExtension(image.FileName);
                    var uniqueFileName = $"{Guid.NewGuid()}{extension}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    await image.CopyToAsync(stream);

                    imageUrls.Add(uniqueFileName);
                }
            }

            F.ImagePath = imageUrls;

            dal.Farmer_Insert(F);

            return Ok("Ad Posted successfully. ✅");
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromForm] Farmer F, [FromForm] List<IFormFile> CustImages)
        {            
            if (!ModelState.IsValid)
            {              
                return BadRequest("Please check and enter valid details.");
            }
            else
            {
                var oldImages = dal.Farmer_Select(F.Custid);

                if(oldImages != null && oldImages.ImagePath != null)
                {
                    var AllOldPaths = oldImages.ImagePath;

                    foreach(var path in AllOldPaths)
                    {
                        var FullOldImgPath = Path.Combine(environment.WebRootPath, "images", path);

                        if (F.ImagePath == null || !F.ImagePath.Contains(path))
                        {
                            if (System.IO.File.Exists(FullOldImgPath))
                            {
                                System.IO.File.Delete(FullOldImgPath);
                            }
                        }                      
                    }
                }
            }

            // Save new uploaded images
            List<string> newUploadedImageUrls = new List<string>();

            if (F.SecondBreed == null)
            {
                F.SecondBreed = "---";
                F.SB_Price = 0;
                F.SB_Pieces = 0;
            }
            if (F.ThirdBreed == null)
            {
                F.ThirdBreed = "---";
                F.TB_Price = 0;
                F.TB_Pieces = 0;
            }

            var uploadsFolder = Path.Combine(environment.WebRootPath, "images");

            if (CustImages != null && CustImages.Count > 0)
            {
                foreach (var image in CustImages)
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

            if (F.ImagePath != null)
            {
                newUploadedImageUrls.AddRange(F.ImagePath);
            }

            F.ImagePath = newUploadedImageUrls;

            dal.Farmer_Update(F);
            
            return Ok("Ad Updated Successfully. ✅");
        }


        [HttpDelete("{custid}")]
        public async Task<IActionResult> DeleteFarmerAd(int custid)
        {
            //First delete old images from folder.

            var oldImages = dal.Farmer_Select(custid);

            if (oldImages != null)
            {
                var AllOldPaths = oldImages.ImagePath;

                foreach (var path in AllOldPaths)
                {
                    var FullOldImgPath = Path.Combine(environment.WebRootPath, "images", path);

                    if (System.IO.File.Exists(FullOldImgPath))
                    {
                        System.IO.File.Delete(FullOldImgPath);
                    }
                }
            }

            //Now delete the record from database
            dal.Farmer_Delete(custid);
            return Ok("Ad deleted successfully. ✅");
        }
    }
}
