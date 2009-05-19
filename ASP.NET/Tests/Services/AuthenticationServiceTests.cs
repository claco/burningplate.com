using System;
using NUnit.Framework;
using BurningPlate.Services;

namespace BurningPlate.Tests.Services
{
    [TestFixture]
    public class AuthenticationServiceTests : ServiceTests<IAuthenticationService>
    {
        [SetUp]
        public override void SetUp()
        {
            Service = new AuthenticationService();
        }

        [Test, Category("Unit")]
        [ExpectedException(typeof(ArgumentException))]
        public void SignInDiesIfUserNameIsEmpty()
        {
            Service.SignIn("", false);

        }
    }
}