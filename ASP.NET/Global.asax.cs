using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Ninject;
using Ninject.Web.Mvc;
using BurningPlate.Services;
using BurningPlate.Repositories;

namespace BurningPlate
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new ControllerModule());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Home",
                "",
                new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                "Restaurants",
                "restaurants",
                new { controller = "Restaurants", action = "Index" }
            );

            routes.MapRoute(
                "Restaurant",
                "restaurant/{id}",
                new { controller = "Restaurants", action = "View" }
            );

            routes.MapRoute(
                "Login",
                "login",
                new {controller = "Account", action = "Login"}
            );

            routes.MapRoute(
                "Logout",
                "logout",
                new { controller = "Account", action = "Logout" }
            );

            routes.MapRoute(
                "Register",
                "register",
                new { controller = "Account", action = "Register" }
            );

            //routes.MapRoute(
            //    "Default",                                              // Route name
            //    "{controller}/{action}/{id}",                           // URL with parameters
            //    new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            //);

            routes.MapRoute(
                "NotFound",
                "{*path}",
                new { controller = "Application", action = "HttpNotFound" }
            );
        }

        protected override void OnApplicationStarted()
        {
            Application["Name"] = "Burning Plate";

            RegisterAllControllersIn(Assembly.GetExecutingAssembly());
            RegisterRoutes(RouteTable.Routes);
        }

        internal class ControllerModule : Ninject.Modules.NinjectModule
        {
            public override void Load()
            {
                Bind<IAuthenticationService>().To<AuthenticationService>();
                Bind<IMembershipService>().To<MembershipService>();
                Bind<MembershipProvider>().ToMethod(p => Membership.Provider);
                Bind<IRestaurantService>().To<RestaurantService>();
                Bind<IRestaurantRepository>().To<SqlRestaurantRepository>();
            }
        }
    }
}