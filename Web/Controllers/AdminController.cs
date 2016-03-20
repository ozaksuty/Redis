using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            RedisCacheManager manager = new RedisCacheManager();
            var categories = manager.Get<List<Categories>>("categories");
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Categories model)
        {
            if (ModelState.IsValid)
            {
                RedisCacheManager manager = new RedisCacheManager();
                manager.Set("categories", model, 60);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddProduct(Products model)
        {
            if (ModelState.IsValid)
            {
                RedisCacheManager manager = new RedisCacheManager();
                manager.Set(model.CategoryId.ToString(), model, 60);
            }
            return RedirectToAction("Index");
        }
    }
}