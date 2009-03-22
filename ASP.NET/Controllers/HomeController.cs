using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

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
