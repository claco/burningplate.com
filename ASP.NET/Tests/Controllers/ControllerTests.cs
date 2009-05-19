using System.Web.Routing;
using Moq;
using NUnit.Framework;
using System.Web;
using System.Web.Mvc;
using BurningPlate.Controllers;

namespace BurningPlate.Tests.Controllers
{
    [TestFixture]
    public class ControllerTests<T> : TestBase where T : Controller
    {
        protected T Controller { get; set; }

        protected ControllerContext FakeContext()
        {
            return FakeContext(null, null);
        }

        protected ControllerContext FakeContext(HttpRequestBase request, HttpResponseBase response)
        {
            var context = new Mock<ControllerContext>();
            var http = new Mock<HttpContextBase>();
            var data = new RouteData();
            
            if (request == null)
            {
                request = new Mock<HttpRequestBase>().Object;
            }
            if (response == null)
            {
                var fakeResponse = new Mock<HttpResponseBase>();
                fakeResponse.SetupProperty(r => r.StatusCode, 200);

                response = fakeResponse.Object;
            }

            http.Setup(c => c.Request).Returns(request);
            http.Setup(c => c.Response).Returns(response);
            
            context.Setup(c => c.HttpContext).Returns(http.Object);
            context.Setup(c => c.Controller).Returns(Controller);
            context.Setup(c => c.RouteData).Returns(data);

            return context.Object;
        }

        protected ControllerContext FakeContext(HttpResponseBase response)
        {
            return FakeContext(null, response);
        }

        protected ControllerContext FakeContext(HttpRequestBase request)
        {
            return FakeContext(request, null);
        }

        protected ActionExecutedContext FakeActionExecutedContext()
        {
            var request = new Mock<HttpRequestBase>();

            return FakeActionExecutedContext(request.Object);
        }

        protected ActionExecutedContext FakeActionExecutedContext(HttpRequestBase request)
        {
            var context = new Mock<ActionExecutedContext>();
            context.Setup(c => c.Controller).Returns(Controller);
            context.Setup(c => c.HttpContext.Request).Returns(request);

            return context.Object;
        }

        protected AppViewModel FakeViewModel()
        {
            var model = new Mock<AppViewModel>();
            model.SetupAllProperties();
            model.Object.Title = string.Empty;

            return model.Object;
        }
    }
}