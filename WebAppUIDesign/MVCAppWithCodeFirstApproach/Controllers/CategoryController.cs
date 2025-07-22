using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppWithCodeFirstApproach.Models;
using System.Data.Entity;

namespace MVCAppWithCodeFirstApproach.Controllers
{
    public class CategoryController : Controller
    {
        StoreDbContext dc = new StoreDbContext();
        public ViewResult DisplayCategories()
        {
            var categories = dc.Categories;
            return View(categories);
        }

        [HttpGet]
        public ViewResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddCategory(Category category)
        {
            dc.Categories.Add(category);
            dc.SaveChanges();

            return RedirectToAction("DisplayCategories");
        }
        public ViewResult EditCategory(int CategoryID)
        {
            Category category = dc.Categories.Find(CategoryID);
            return View(category);
        }
        public RedirectToRouteResult UpdateCategory(Category category)
        {
            dc.Entry(category).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayCategories");
        }
        public RedirectToRouteResult DeleteCategory(int CategoryID)
        {
            Category category = dc.Categories.Find(CategoryID);
            dc.Categories.Remove(category);
            dc.SaveChanges();
            return RedirectToAction("DisplayCategories");
        }
    }
}