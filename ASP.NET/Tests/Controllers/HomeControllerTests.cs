using System.Web.Mvc;
using NUnit.Framework;
using BurningPlate.Controllers;

namespace BurningPlate.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests : ControllerTests<HomeController>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            Controller = new HomeController();
        }

        [Test, Category("Unit")]
        public void CanLoadIndex()
        {
            var result = (ViewResult) Controller.Index();

            Expect(result, Not.Null);
        }
    }
}