using System;
using System.Linq;
using System.Transactions;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using BurningPlate.Repositories;
using BurningPlate.Models;

namespace BurningPlate.Tests.Repositories
{
    [TestFixture]
    public class SqlRestaurantRepositoryTests : RepositoryTests<IRestaurantRepository>
    {
        [SetUp]
        public override void SetUp()
        {
            Repository = new SqlRestaurantRepository();    
        }

        [Test, Category("Unit")]
        public void CanGetRestaurantById()
        {
            using (var txn = new TransactionScope())
            {
                var id = Guid.NewGuid();
                var context = new BurningPlate.Data.BurningPlateDataContext();
                context.Restaurants.InsertOnSubmit(new Data.Restaurant(){Id=id, Name="TestRestaurant", Created=DateTime.UtcNow, Updated=DateTime.UtcNow});
                context.SubmitChanges();

                var restaurant = Repository.GetById(id);

                Expect(restaurant, Is.InstanceOfType(typeof(Restaurant)));
                Expect(restaurant.Id, Is.EqualTo(id));
                Expect(restaurant.Name, Is.EqualTo("TestRestaurant"));
            }
        }

        [Test, Category("Unit")]
        public void CanQueryRestaurants()
        {
            using (var txn = new TransactionScope())
            {
                var id = Guid.NewGuid();
                var context = new BurningPlate.Data.BurningPlateDataContext();
                context.Restaurants.InsertOnSubmit(new Data.Restaurant() { Id = id, Name = "TestRestaurant", Created = DateTime.UtcNow, Updated = DateTime.UtcNow });
                context.SubmitChanges();
                context.Dispose();

                //var restaurants = Repository.All();
                //var restaurant = restaurants.Where(r => r.Id == id).First();

                var restaurant = Repository.All().Where(r => r.Name == "BW<3").ToList().First();
                //var restaurant = Repository.All().Where(r => r.Id == id).ToList().First();
                
                //Expect(restaurants, Is.InstanceOfType(typeof(IQueryable<Restaurant>)));
                Expect(restaurant, Is.InstanceOfType(typeof (Restaurant)));
                Expect(restaurant.Id, Is.EqualTo(new Guid("088ec7f4-63e8-4e3a-902f-fc6240df0a4b")));
                Expect(restaurant.Name, Is.EqualTo("BW<3"));
            }
        }
    }
}