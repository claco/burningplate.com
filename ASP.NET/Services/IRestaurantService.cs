using System;
using System.Collections.Generic;
using BurningPlate.Models;

namespace BurningPlate.Services
{
    public interface IRestaurantService
    {
        IList<Restaurant> All();

        Restaurant GetById(Guid id);
    }
}