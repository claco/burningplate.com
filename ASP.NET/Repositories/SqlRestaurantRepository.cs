using System;
using System.Linq;
using BurningPlate.Models;

namespace BurningPlate.Repositories
{
    public class SqlRestaurantRepository : IRestaurantRepository
    {
        readonly Data.BurningPlateDataContext _context = new Data.BurningPlateDataContext();

        public IQueryable<Restaurant> All()
        {
            return from r in _context.Restaurants select new Restaurant
                {
                    Id = r.Id,
                    Name = r.Name
                };
        }

        public Restaurant GetById(Guid id)
        {
            var results = from r in _context.Restaurants
                          where r.Id == id
                          select new Restaurant
                                     {
                                         Id = r.Id,
                                         Name = r.Name
                                     };

            return results.SingleOrDefault();
        }
    }
}
