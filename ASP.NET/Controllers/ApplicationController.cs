using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace BurningPlate.Controllers
{
    public class ApplicationController : Controller
    {
        public ActionResult HttpNotFound()
        {
            return new HttpNotFoundResult();
        }
    }

    public class HttpNotFoundResult : ViewResult
    {
        public HttpNotFoundResult()
        {
            this.ViewData["Title"] = "Resource Not Found";
        }

        public HttpNotFoundResult(string message)
        {
            this.ViewData["Title"] = message;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = 404;
            this.ViewName = "Errors/404";

            base.ExecuteResult(context);
        }
    }
}
