using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWebApp.Repositories
{
    public class UserRepository
    {
        private RestaurantDatabaseEntities objRestaurantDatabaseEntities;
        public UserRepository()
        {
            objRestaurantDatabaseEntities = new RestaurantDatabaseEntities();
        }

        public IEnumerable<SelectListItem> GetAllUsers()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestaurantDatabaseEntities.Users
                                  select new SelectListItem()
                                  {
                                      Text = obj.Username,
                                      Value = obj.UserID.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}