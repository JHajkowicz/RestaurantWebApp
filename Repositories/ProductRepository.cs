using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantWebApp.Models;
namespace RestaurantWebApp.Repositories
{
    public class ProductRepository
    {
        private RestaurantDatabaseEntities objRestaurantDatabaseEntities;
        public ProductRepository()
        {
            objRestaurantDatabaseEntities = new RestaurantDatabaseEntities();
        }

        public IEnumerable<SelectListItem> GetAllProducts()
        {

            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestaurantDatabaseEntities.Products
                                  select new SelectListItem()
                                  {
                                      Text = obj.ProductName,
                                      Value = obj.ProductID.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}
