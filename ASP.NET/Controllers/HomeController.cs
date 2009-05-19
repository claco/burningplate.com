using System.Web.Mvc;

namespace BurningPlate.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
