using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurningPlate.Models
{
    public partial class Restaurants
    {
        public static IEnumerable<Restaurant> All()
        {
            using (var dbo = new BurningPlateDataContext())
            {
                return dbo.Restaurants.ToList();
            }
        }

        public static Restaurant GetById(int id)
        {
            using (var dbo = new BurningPlateDataContext()) {
                return dbo.Restaurants.SingleOrDefault(p => p.Id == id);
            }
        }
    }
}
