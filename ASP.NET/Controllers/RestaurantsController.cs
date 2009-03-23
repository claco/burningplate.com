using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BurningPlate.Models;

namespace BurningPlate.Controllers
{
    public class RestaurantsController : ApplicationController
    {
        public ActionResult Index()
        {
            IEnumerable<Restaurant> restaurants = Restaurants.All();

            return View(restaurants);
        }

        public ActionResult View(int? id)
        {
            Restaurant restaurant = id.HasValue ? Restaurants.GetById(id.Value) : null;

            if (restaurant == null)
            {
                return new HttpNotFoundResult("Restaurant Not Found");
            }
            else
            {
                ViewData["Title"] = restaurant.Name;

                return View(restaurant);
            }
        }
    }
}
