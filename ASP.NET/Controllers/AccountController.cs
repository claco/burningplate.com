using System.Web.Mvc;
using System.Web.Security;
using BurningPlate.Services;

namespace BurningPlate.Controllers
{
    public class AccountController : ApplicationController
    {
        public AccountController(IMembershipService membership, IAuthenticationService authentication)
        {
            Membership = membership;
            Authentication = authentication;
        }

        protected IMembershipService Membership { get; private set; }

        protected IAuthenticationService Authentication { get; private set; }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Login()
        {
            ViewData.Model = new AppViewModel { Title = "Login" };

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken(Salt="LoginForm")]
        public ActionResult Login(string userName, string password, bool remember)
        {
            if (string.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("UserName", "User name is required.");
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Password", "Password is required.");
            }

            if (ModelState.IsValid && Membership.ValidateUser(userName, password))
            {
                ViewData.Model = new AppViewModel { IsAuthenticated = true, Title = "Login Successful" };
                Authentication.SignIn(userName, remember);

                return RedirectToRoute("Home");
            }
            else
            {
                ViewData.Model = new AppViewModel { IsAuthenticated = false, Title = "Login Failed" };
            }

            return View();
        }

        public ActionResult Logout()
        {
            ViewData.Model = new AppViewModel {IsAuthenticated = false, Title = "Logout Successful"};
            Authentication.SignOut();

            return RedirectToRoute("Home");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Register()
        {
            ViewData.Model = new AppViewModel { Title = "Register" };

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken(Salt = "RegisterForm")]
        public ActionResult Register(string userName, string password, string emailAddress)
        {
            if (string.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("UserName", "User name is required.");
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Password", "Password is required.");
            }
            if (string.IsNullOrEmpty(emailAddress))
            {
                ModelState.AddModelError("EmailAddress", "Email address is required.");
            }

            if (ModelState.IsValid)
            {
                var status = Membership.CreateUser(userName, password, emailAddress);

                if (status == MembershipCreateStatus.Success)
                {
                    Authentication.SignIn(userName, false);
                    ViewData.Model = new AppViewModel { IsAuthenticated = true, Title = "Registration Successful" };

                    return RedirectToRoute("Home");
                }
                else
                {
                    switch (status)
                    {
                        case MembershipCreateStatus.DuplicateUserName:
                            ModelState.AddModelError("UserName", "User name already exists.");
                            break;
                        case MembershipCreateStatus.DuplicateEmail:
                            ModelState.AddModelError("EmailAddress", "Email address already exists.");
                            break;
                        default:
                            ModelState.AddModelError("_FORM", status.ToString());
                            break;
                    }
                }
            }

            ViewData.Model = new AppViewModel {IsAuthenticated = false, Title = "Registration Failed" };

            return View(); 
        }
    }
}
