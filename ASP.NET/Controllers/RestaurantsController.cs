using System;
using System.Web.Mvc;
using BurningPlate.Services;

namespace BurningPlate.Controllers
{
    public class RestaurantsController : Controller
    {
        public RestaurantsController(IRestaurantService service)
        {
            Service = service;            
        }

        protected IRestaurantService Service { get; set; }

        public ActionResult Index()
        {
            ViewData.Model = new RestaurantsViewModel {Title = "Restaurants", Restaurants = Service.All()};

            return View();
        }

        public ActionResult View(Guid? id)
        {
            if (id.HasValue)
            {
                var restaurant = Service.GetById(id.Value);

                if (restaurant != null)
                {
                    ViewData.Model = new RestaurantsViewModel { Title = restaurant.Name, Restaurant = restaurant };

                    return View();
                }   
            }

            ViewData.Model = new RestaurantsViewModel { Title = "Restaurant Not Found"};
            Response.StatusCode = 404;

            return View();
        }
    }
}
