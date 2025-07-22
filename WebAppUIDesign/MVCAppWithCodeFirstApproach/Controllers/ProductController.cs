using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppWithCodeFirstApproach.Models;
using System.Data.Entity;
using System.IO;

namespace MVCAppWithCodeFirstApproach.Controllers
{
    public class ProductController : Controller
    {
        StoreDbContext dc = new StoreDbContext();

        public ViewResult DisplayProducts()
        {
            dc.Configuration.LazyLoadingEnabled = true;
            var products = dc.Products.Include(P => P.Category).Where(P => P.Discontinued == false);

            return View(products);
        }

        public ViewResult Displayproduct(int id)
        {
            dc.Configuration.LazyLoadingEnabled = false;
            Product Product = (dc.Products.Include(P =>  P.Category).Where(P => P.Id == id & P.Discontinued ==false).Single());
            return View(Product);
        }

        [HttpGet]
        public ViewResult AddProduct()
        {
            //this below line of code will connect to database and go to the categories table in database and get categoryid and categoryname and keep them into select list
            //in key value pairs(datavaluefield, datatextfield). these are now passed to next request using viewbag to be used in the dropdown in the view.
            //This categoryid passed to view and it contains select list in it. so when user click on dropdown in UI, he sees categoryname and when he selects category name 
            //in the backend it selects categoryid and when user clicks save it saves categoryid to the database in the backend.
            ViewBag.CategoryId = new SelectList(dc.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddProduct(Product Product, HttpPostedFileBase selectedFile)
        {
            if(selectedFile != null)
            {
                string DirectoryPath = Server.MapPath("~/Uploads/");
                if(!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                selectedFile.SaveAs(DirectoryPath + selectedFile.FileName);

                BinaryReader br = new BinaryReader(selectedFile.InputStream);
                Product.ProductImage = br.ReadBytes(selectedFile.ContentLength);

                Product.ProductImageName = selectedFile.FileName;
            }
            dc.Products.Add(Product);
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }

        public ViewResult EditProduct(int id)
        {
            Product product = dc.Products.Find(id);
            TempData["ProductImage"] = product.ProductImage;
            TempData["ProductImageName"] = product.ProductImageName;
            ViewBag.CategoryId = new SelectList(dc.Categories, "CategoryId", "CategoryName", product.CategoryId);

            return View(product);
        }

        public RedirectToRouteResult UpdateProduct(Product product, HttpPostedFileBase selectedFile)
        {
            if(selectedFile != null)
            {
                string DirectoryPath = Server.MapPath("~/Uploads/");
                if(!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                selectedFile.SaveAs (DirectoryPath + selectedFile.FileName);

                BinaryReader br = new BinaryReader(selectedFile.InputStream);
                product.ProductImage = br.ReadBytes(selectedFile.ContentLength);

                product.ProductImageName = selectedFile.FileName;
            }
            else if (TempData["ProductImage"] != null && TempData["ProductImageName"] != null)
            {
                product.ProductImage = (byte[])TempData["ProductImage"];
                product.ProductImageName = (string)TempData["ProductImageName"];
            }
            dc.Entry(product).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }

        public RedirectToRouteResult DeleteProduct(int id)
        {
            Product product = dc.Products.Find(id);
            product.Discontinued = true;
            dc.Entry (product).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayProducts");
        }
    }
}