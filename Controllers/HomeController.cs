using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantWebApp.Models;
using RestaurantWebApp.Repositories;
using RestaurantWebApp.ViewModels;

namespace RestaurantWebApp.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDatabaseEntities objRestaurantDatabaseEntities;
        public HomeController()
        { objRestaurantDatabaseEntities = new RestaurantDatabaseEntities(); }

        //GET: Home
        public ActionResult Index()
        {
            ProductRepository objProductRepository = new ProductRepository();
            UserRepository objUserRepository = new UserRepository();
            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objProductRepository.GetAllProducts(), objUserRepository.GetAllUsers());
            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult getProductUnitPrice(int productID)
        {
            decimal UnitPrice = objRestaurantDatabaseEntities.Products.Single(model => model.ProductID == productID).productPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewModel);
            return Json(data: "Zamowienie zostalo zlozone", JsonRequestBehavior.AllowGet);
        }

    }
}
