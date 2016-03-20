using Data;
using Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var mainModel = new List<Products>();
            RedisCacheManager manager = new RedisCacheManager();
            var categories = manager.Get<List<Categories>>("categories");
            if (categories != null)
            {
                foreach (var item in categories)
                {
                    var products = manager.Get<List<Products>>(item.Id.ToString());
                    if (products != null)
                        mainModel.AddRange(products);
                }
            }
            ViewBag.Categories = categories;
            return View(mainModel);
        }

        public ActionResult Category(int id)
        {
            RedisCacheManager manager = new RedisCacheManager();
            var products = manager.Get<List<Products>>(id.ToString());
            return View(products);
        }
    }
}