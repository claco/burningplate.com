using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Moq;
using System.Web.Security;
using BurningPlate.Services;

namespace BurningPlate.Tests.Services
{
    [TestFixture]
    public class MembershipServiceTests : ServiceTests<IMembershipService>
    {
        Mock<MembershipProvider> _provider;

        [SetUp]
        public override void SetUp()
        {
            _provider = new Mock<MembershipProvider>();

            Service = new MembershipService(_provider.Object);
        }

        [Test, Category("Unit")]
        public void CanValidateUser()
        {
            _provider.Setup(p => p.ValidateUser("username", "password")).Returns(true);
            Expect(Service.ValidateUser("username", "password"), Is.True);
            _provider.Verify(p => p.ValidateUser("username", "password"));
        }

        [Test, Category("Unit")]
        public void ValidationFailsWithEmptyUserName()
        {
            _provider.Setup(p => p.ValidateUser("", "password")).Returns(false);
            Expect(Service.ValidateUser("", "password"), Is.False);
            _provider.Verify(p => p.ValidateUser("", "password"));
        }

        [Test, Category("Unit")]
        public void ValidationFailsWithEmptyPassword()
        {
            _provider.Setup(p => p.ValidateUser("username", "")).Returns(false);
            Expect(Service.ValidateUser("username", ""), Is.False);
            _provider.Verify(p => p.ValidateUser("username", ""));
        }

        [Test, Category("Unit")]
        public void ValidationFailsWithIncorrectUserName()
        {
            _provider.Setup(p => p.ValidateUser("bogons", "password")).Returns(false);
            Expect(Service.ValidateUser("bogons", "password"), Is.False);
            _provider.Verify(p => p.ValidateUser("bogons", "password"));
        }

        [Test, Category("Unit")]
        public void ValidationFailsWithIncorrectPassword()
        {
            _provider.Setup(p => p.ValidateUser("username", "bogons")).Returns(false);
            Expect(Service.ValidateUser("username", "bogons"), Is.False);
            _provider.Verify(p => p.ValidateUser("username", "bogons"));
        }

        [Test, Category("Unit")]
        public void CreateFailsWithEmptyUserName()
        {
            MembershipCreateStatus setupStatus = MembershipCreateStatus.InvalidUserName;

            _provider.Setup(p => p.CreateUser("", "password", "user@example.com", null, null, true, null, out setupStatus));
            var status = Service.CreateUser("", "password", "user@example.com");

            Expect(status, Is.EqualTo(MembershipCreateStatus.InvalidUserName));
        }

        [Test, Category("Unit")]
        public void CreateFailsWithEmptyPassword()
        {
            MembershipCreateStatus status = MembershipCreateStatus.ProviderError;
            MembershipCreateStatus setupStatus = MembershipCreateStatus.InvalidPassword;

            _provider.Setup(p => p.CreateUser("username", "", "user@example.com", null, null, true, null, out setupStatus));
            status = Service.CreateUser("username", "", "user@example.com");

            Expect(status, Is.EqualTo(MembershipCreateStatus.InvalidPassword));
        }

        [Test, Category("Unit")] public void CreateFailsWithEmptyEmailAddress()
        {
            MembershipCreateStatus setupStatus = MembershipCreateStatus.InvalidEmail;

            _provider.Setup(p => p.CreateUser("username", "password", "", null, null, true, null, out setupStatus));
            var status = Service.CreateUser("username", "password", "");

            Expect(status, Is.EqualTo(MembershipCreateStatus.InvalidEmail));
        }

        [Test, Category("Unit")]
        public void CreateFailsWhenEmailAddressExists()
        {
            MembershipCreateStatus setupStatus = MembershipCreateStatus.DuplicateEmail;

            _provider.Setup(p => p.CreateUser("username", "password", "exists@example.com", null, null, true, null, out setupStatus));
            var status = Service.CreateUser("username", "password", "exists@example.com");

            Expect(status, Is.EqualTo(MembershipCreateStatus.DuplicateEmail));
        }

        [Test, Category("Unit")]
        public void CreateFailsWhenUserNameExists()
        {
            MembershipCreateStatus setupStatus = MembershipCreateStatus.DuplicateUserName;

            _provider.Setup(p => p.CreateUser("exists", "password", "user@example.com", null, null, true, null, out setupStatus));
            var status = Service.CreateUser("exists", "password", "user@example.com");

            Expect(status, Is.EqualTo(MembershipCreateStatus.DuplicateUserName));
        }

        [Test, Category("Unit")]
        public void CreateSucceeds()
        {
            MembershipCreateStatus setupStatus = MembershipCreateStatus.Success;

            _provider.Setup(p => p.CreateUser("username", "password", "user@example.com", null, null, true, null, out setupStatus));
            var status = Service.CreateUser("username", "password", "user@example.com");

            Expect(status, Is.EqualTo(MembershipCreateStatus.Success));
            _provider.Verify(p => p.CreateUser("username", "password", "user@example.com", null, null, true, null, out setupStatus));
        }
    }
}