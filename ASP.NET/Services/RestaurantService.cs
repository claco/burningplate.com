using System;
using System.Linq;
using System.Collections.Generic;
using BurningPlate.Models;
using BurningPlate.Repositories;

namespace BurningPlate.Services
{
    public class RestaurantService : IRestaurantService
    {
        public RestaurantService(IRestaurantRepository repository)
        {
            Repository = repository;
        }

        protected IRestaurantRepository Repository { get; private set; }

        public IList<Restaurant> All()
        {
            return Repository.All().ToList();
        }

        public Restaurant GetById(Guid id)
        {
            return Repository.GetById(id);
        }
    }
}