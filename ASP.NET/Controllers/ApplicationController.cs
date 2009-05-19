using System;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace BurningPlate.Controllers
{
    public class ApplicationController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var model = (AppViewModel) filterContext.Controller.ViewData.Model;

            // Ensure we always have a view model
            if (model == null)
            {
                model = new AppViewModel();
                filterContext.Controller.ViewData.Model = model;
            }

            // Ensure we always have a page title
            if (String.IsNullOrEmpty(model.Title))
            {
                var matches = Regex.Match(filterContext.Controller.ToString(), "\\.([a-z]*)Controller\\Z", RegexOptions.IgnoreCase);
                model.Title = matches.Groups[1].Value;
            }

            // Set IsAuthenticated, unless it's already true
            if (!model.IsAuthenticated)
            {
                model.IsAuthenticated = filterContext.HttpContext.Request.IsAuthenticated;
            }
        }

        public ActionResult HttpNotFound()
        {
            ViewData.Model = new AppViewModel {Title = "Resource Not Found"};
            Response.StatusCode = 404;

            return View("Errors/404");
        }
    }
}
