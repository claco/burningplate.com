using System.Web.Mvc;
using System.Web.Security;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Moq;
using BurningPlate.Controllers;
using BurningPlate.Services;

namespace BurningPlate.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTests : ControllerTests<AccountController>
    {
        Mock<IMembershipService> _membership;
        private Mock<IAuthenticationService> _authentication;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _membership = new Mock<IMembershipService>();
            _membership.Setup(m => m.ValidateUser("username", "password")).Returns(true);
            _authentication = new Mock<IAuthenticationService>();

            Controller = new AccountController(_membership.Object, _authentication.Object);
        }

        [Test, Category("Unit")]
        public void LoginFailsWithBlankUserName()
        {
            var result = (ViewResult) Controller.Login("", "password", false);
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result, Is.InstanceOfType(typeof (ViewResult)));
            Expect(model.IsAuthenticated, Is.False);
            Expect(model.Title, Text.EndsWith("Login Failed"));
            Expect(modelState.IsValid, Is.False);
            Expect(modelState["UserName"].Errors[0].ErrorMessage, Text.Matches("User.*Name.*Required").IgnoreCase);
        }

        [Test, Category("Unit")]
        public void LoginFailsWithBlankPassword()
        {
            var result = (ViewResult)Controller.Login("username", "", false);
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result, Is.InstanceOfType(typeof(ViewResult)));
            Expect(model.IsAuthenticated, Is.False);
            Expect(model.Title, Text.EndsWith("Login Failed"));
            Expect(modelState.IsValid, Is.False);
            Expect(modelState["Password"].Errors[0].ErrorMessage, Text.Matches("Password.*Required").IgnoreCase);
        }

        [Test, Category("Unit")]
        public void LoginFailsWithBadPassword()
        {
            var result = (ViewResult)Controller.Login("username", "bogons", false);
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result, Is.InstanceOfType(typeof(ViewResult)));
            Expect(model.IsAuthenticated, Is.False);
            Expect(model.Title, Text.EndsWith("Login Failed"));
            Expect(modelState.IsValid, Is.True);
            _membership.Verify(m => m.ValidateUser("username", "bogons"));                
        }

        [Test, Category("Unit")]
        public void LoginSucceeds()
        {
            var result = (RedirectToRouteResult)Controller.Login("username", "password", false);
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result.RouteName, Is.EqualTo("Home"));
            Expect(model.IsAuthenticated, Is.True);
            Expect(model.Title, Text.EndsWith("Login Successful"));
            Expect(modelState.IsValid, Is.True);
            _membership.Verify(m => m.ValidateUser("username", "password"));
            _authentication.Verify(a => a.SignIn("username", false));
        }

        [Test, Category("Unit")]
        public void LoginSucceedAndRemembers()
        {
            var result = (RedirectToRouteResult)Controller.Login("username", "password", true);
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result.RouteName, Is.EqualTo("Home"));
            Expect(model.IsAuthenticated, Is.True);
            Expect(model.Title, Text.EndsWith("Login Successful"));
            Expect(modelState.IsValid, Is.True);
            _membership.Verify(m => m.ValidateUser("username", "password"));
            _authentication.Verify(a => a.SignIn("username", true));
        }

        [Test, Category("Unit")]
        public void LogoutSucceeds()
        {
            Controller.ViewData.Model = FakeViewModel();
            ((AppViewModel) Controller.ViewData.Model).IsAuthenticated = true;

            var result = (RedirectToRouteResult) Controller.Logout();
            var model = (AppViewModel)Controller.ViewData.Model;

            Expect(result.RouteName, Is.EqualTo("Home"));
            Expect(model.IsAuthenticated, Is.False);
            Expect(model.Title, Text.EndsWith("Logout Successful"));
            _authentication.Verify(a => a.SignOut());
        }

        [Test, Category("Unit")]
        public void RegisterFailsWithBlankEmailAddress()
        {
            var result = (ViewResult)Controller.Register("username", "password", "");
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result, Is.InstanceOfType(typeof(ViewResult)));
            Expect(model.IsAuthenticated, Is.False);
            Expect(model.Title, Text.EndsWith("Registration Failed"));
            Expect(modelState.IsValid, Is.False);
            Expect(modelState["EmailAddress"].Errors[0].ErrorMessage, Text.Matches("Email.*Address.*Required").IgnoreCase);
        }

        [Test, Category("Unit")]
        public void RegisterFailsWithBlankUserName()
        {
            var result = (ViewResult)Controller.Register("", "password", "user@example.com");
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result, Is.InstanceOfType(typeof(ViewResult)));
            Expect(model.IsAuthenticated, Is.False);
            Expect(model.Title, Text.EndsWith("Registration Failed"));
            Expect(modelState.IsValid, Is.False);
            Expect(modelState["UserName"].Errors[0].ErrorMessage, Text.Matches("User.*Name.*Required").IgnoreCase);
        }

        [Test, Category("Unit")]
        public void RegisterFailsWithBlankPassword()
        {
            var result = (ViewResult)Controller.Register("username", "", "user@example.com");
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result, Is.InstanceOfType(typeof(ViewResult)));
            Expect(model.IsAuthenticated, Is.False);
            Expect(model.Title, Text.EndsWith("Registration Failed"));
            Expect(modelState.IsValid, Is.False);
            Expect(modelState["Password"].Errors[0].ErrorMessage, Text.Matches("Password.*Required").IgnoreCase);
        }

        [Test, Category("Unit")]
        public void RegisterFailsWhenUserNameExists()
        {
            _membership.Setup(m => m.CreateUser("exists", "password", "user@example.com")).Returns(MembershipCreateStatus.DuplicateUserName);
            var result = (ViewResult)Controller.Register("exists", "password", "user@example.com");
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result, Is.InstanceOfType(typeof(ViewResult)));
            Expect(model.IsAuthenticated, Is.False);
            Expect(model.Title, Text.EndsWith("Registration Failed"));
            Expect(modelState.IsValid, Is.False);
            Expect(modelState["UserName"].Errors[0].ErrorMessage, Text.Matches("User.*Name.*Exists").IgnoreCase);
            _membership.Verify(m => m.CreateUser("exists", "password", "user@example.com"));
        }

        [Test, Category("Unit")]
        public void RegisterFailsWhenEmailAddressExists()
        {
            _membership.Setup(m => m.CreateUser("username", "password", "exists@example.com")).Returns(MembershipCreateStatus.DuplicateEmail);
            var result = (ViewResult)Controller.Register("username", "password", "exists@example.com");
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result, Is.InstanceOfType(typeof(ViewResult)));
            Expect(model.IsAuthenticated, Is.False);
            Expect(model.Title, Text.EndsWith("Registration Failed"));
            Expect(modelState.IsValid, Is.False);
            Expect(modelState["EmailAddress"].Errors[0].ErrorMessage, Text.Matches("Email.*Address.*Exists").IgnoreCase);
            _membership.Verify(m => m.CreateUser("username", "password", "exists@example.com"));
        }

        [Test, Category("Unit")]
        public void RegisterFailsWithProviderError()
        {
            _membership.Setup(m => m.CreateUser("username", "password", "user@example.com")).Returns(MembershipCreateStatus.ProviderError);
            var result = (ViewResult)Controller.Register("username", "password", "user@example.com");
            var model = (AppViewModel)Controller.ViewData.Model;
            var modelState = Controller.ModelState;

            Expect(result, Is.InstanceOfType(typeof(ViewResult)));
            Expect(model.IsAuthenticated, Is.False);
            Expect(model.Title, Text.EndsWith("Registration Failed"));
            Expect(modelState.IsValid, Is.False);
            Expect(modelState["_FORM"].Errors[0].ErrorMessage, Text.Matches("Provider.*Error").IgnoreCase);
            _membership.Verify(m => m.CreateUser("username", "password", "user@example.com"));
        }

        [Test, Category("Unit")]
        public void RegisterSucceeds()
        {
            _membership.Setup(m => m.CreateUser("username", "password", "user@example.com")).Returns(MembershipCreateStatus.Success);
            _authentication.Setup(a => a.SignIn("username", false));
            var result = (RedirectToRouteResult)Controller.Register("username", "password", "user@example.com");
            var model = (AppViewModel)Controller.ViewData.Model;

            Expect(result.RouteName, Is.EqualTo("Home"));
            Expect(model.IsAuthenticated, Is.True);
            Expect(model.Title, Text.EndsWith("Registration Successful"));
            _authentication.Verify(a => a.SignIn("username", false));
            _membership.Verify(m => m.CreateUser("username", "password", "user@example.com"));
        }
    }
}