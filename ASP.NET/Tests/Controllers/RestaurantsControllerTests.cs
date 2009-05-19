using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Moq;
using BurningPlate.Controllers;
using BurningPlate.Models;
using BurningPlate.Services;

namespace BurningPlate.Tests.Controllers
{
    [TestFixture]
    public class RestaurantsContollerTests : ControllerTests<RestaurantsController>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            var service = new Mock<IRestaurantService>();
            var data = new List<Restaurant>
                           {
                               new Restaurant {Id = new Guid("11111111-1111-1111-1111-111111111111"), Name = "Restaurant1"},
                               new Restaurant {Id = new Guid("22222222-2222-2222-2222-222222222222"), Name = "Restaurant2"}
                           };
            service.Setup(s => s.All()).Returns(data);
            service.Setup(s => s.GetById(new Guid("11111111-1111-1111-1111-111111111111"))).Returns(data[0]);

            Controller = new RestaurantsController(service.Object);
            Controller.ControllerContext = FakeContext();
        }

        [Test, Category("Unit")]
        public void CanViewRestaurants()
        {
            var result = (ViewResult) Controller.Index();
            var model = (RestaurantsViewModel) Controller.ViewData.Model;

            Expect(result, Not.Null);
            Expect(model.Title, Text.EndsWith("Restaurants"));
            Expect(model.Restaurants, Is.InstanceOfType(typeof(IList<Restaurant>)));
            Expect(model.Restaurants.Count, Is.EqualTo(2));
        }

        [Test, Category("Unit")]
        public void CanViewRestaurantById()
        {
            var result = (ViewResult)Controller.View(new Guid("11111111-1111-1111-1111-111111111111"));
            var model = (RestaurantsViewModel)Controller.ViewData.Model;

            Expect(result, Not.Null);
            Expect(model.Title, Text.EndsWith("Restaurant1"));
            Expect(model.Restaurant, Is.InstanceOfType(typeof(Restaurant)));
            Expect(model.Restaurant.Id, Is.EqualTo(new Guid("11111111-1111-1111-1111-111111111111")));
            Expect(model.Restaurant.Name, Is.EqualTo("Restaurant1"));
        }

        [Test, Category("Unit")]
        public void RestaurantNotFoundForId()
        {
            var result = (ViewResult)Controller.View(Guid.NewGuid());
            var model = (RestaurantsViewModel)Controller.ViewData.Model;

            Expect(result, Not.Null);
            Expect(model.Title, Text.EndsWith("Restaurant Not Found"));
            Expect(model.Restaurant, Is.Null);
            Expect(Controller.HttpContext.Response.StatusCode, Is.EqualTo(404));
        }
    }
}