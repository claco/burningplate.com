using System;
using System.Collections.Generic;
using BurningPlate.Models;

namespace BurningPlate.Controllers
{
    public class RestaurantsViewModel : AppViewModel
    {
        public IList<Restaurant> Restaurants { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}