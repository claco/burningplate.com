using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Moq;
using BurningPlate.Services;
using BurningPlate.Repositories;
using BurningPlate.Models;

namespace BurningPlate.Tests.Services
{
    [TestFixture]
    public class RestaurantServiceTests : ServiceTests<IRestaurantService>
    {
        [SetUp]
        public override void SetUp()
        {
            var repository = new Mock<IRestaurantRepository>();
            var data = new List<Restaurant>
                           {
                               new Restaurant {Id = new Guid("11111111-1111-1111-1111-111111111111"), Name = "Restaurant1"},
                               new Restaurant {Id = new Guid("22222222-2222-2222-2222-222222222222"), Name = "Restaurant2"}
                           };
            repository.Setup(r => r.GetById(new Guid("11111111-1111-1111-1111-111111111111"))).Returns(data[0]);
            repository.Setup(r => r.All()).Returns(data.AsQueryable);
            Service = new RestaurantService(repository.Object);
        }

        [Test, Category("Unit")]
        public void CanReturnRestaurants()
        {
            var restaurants = Service.All();

            Expect(restaurants, Is.InstanceOfType(typeof(IList<Restaurant>)));

            var restaurant = restaurants[0];

            Expect(restaurant, Is.InstanceOfType(typeof(Restaurant)));
            Expect(restaurant.Id, Is.EqualTo(new Guid("11111111-1111-1111-1111-111111111111")));
            Expect(restaurant.Name, Is.EqualTo("Restaurant1"));
        }

        [Test, Category("Unit")]
        public void CanReturnRestaurantById()
        {
            var restaurant = Service.GetById(new Guid("11111111-1111-1111-1111-111111111111"));

            Expect(restaurant, Is.InstanceOfType(typeof (Restaurant)));
            Expect(restaurant.Id, Is.EqualTo(new Guid("11111111-1111-1111-1111-111111111111")));
            Expect(restaurant.Name, Is.EqualTo("Restaurant1"));
        }
    }
}