using System.Web;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using BurningPlate.Controllers;

namespace BurningPlate.Tests.Controllers
{
    [TestFixture]
    public class ApplicationControllerTests : ControllerTests<ApplicationController>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            Controller = new ApplicationController();
        }

        [Test, Category("Unit")]
        public void ViewModelCreatedWhenModelIsEmpty()
        {
            Expect(Controller.ViewData.Model, Is.Null);

            ((IActionFilter)Controller).OnActionExecuted( FakeActionExecutedContext() );
            
            Expect(Controller.ViewData.Model, Is.Not.Null);
            Expect(Controller.ViewData.Model, Is.InstanceOfType(typeof(AppViewModel)));
        }

        [Test, Category("Unit")]
        public void TitleSetToControllerNameWhenTitleIsEmpty()
        {
            var model = FakeViewModel();

            Controller.ViewData.Model = model;
            Expect(model.Title, Is.Empty);

            ((IActionFilter)Controller).OnActionExecuted(FakeActionExecutedContext());

            Expect(model.Title, Text.EndsWith("Application"));
        }

        [Test, Category("Unit")]
        public void IsAuthenticatedIsSetFromRequest()
        {
            var model = FakeViewModel();
            var request = new Mock<HttpRequestBase>();
            request.Setup(r => r.IsAuthenticated).Returns(true);
            Controller.ViewData.Model = model;

            Expect(model.IsAuthenticated, Is.False);

            ((IActionFilter)Controller).OnActionExecuted(FakeActionExecutedContext(request.Object));

            Expect(model.IsAuthenticated, Is.True);
        }

        [Test, Category("Unit")]
        public void IsAuthenticatedStillTrueIfRequestIsFalse()
        {
            var model = FakeViewModel();
            model.IsAuthenticated = true;

            var request = new Mock<HttpRequestBase>();
            request.Setup(r => r.IsAuthenticated).Returns(false);
            Controller.ViewData.Model = model;

            Expect(request.Object.IsAuthenticated, Is.False);
            Expect(model.IsAuthenticated, Is.True);

            ((IActionFilter)Controller).OnActionExecuted(FakeActionExecutedContext(request.Object));

            Expect(model.IsAuthenticated, Is.True);
        }
    }
}