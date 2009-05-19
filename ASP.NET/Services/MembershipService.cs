using System.Web.Security;

namespace BurningPlate.Services
{
    public class MembershipService : IMembershipService
    {
        public MembershipService(MembershipProvider provider)
        {
            Provider = provider;
        }

        protected MembershipProvider Provider { get; private set; }

        public bool ValidateUser(string userName, string password)
        {
            return Provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string emailAddress)
        {
            if (string.IsNullOrEmpty(userName)) 
            {
                return MembershipCreateStatus.InvalidUserName;
            }
            else if (string.IsNullOrEmpty(password))
            {
                return MembershipCreateStatus.InvalidPassword;
            }
            else if (string.IsNullOrEmpty(emailAddress))
            {
                return MembershipCreateStatus.InvalidEmail;
            }
            else
            {
                MembershipCreateStatus status;

                Provider.CreateUser(userName, password, emailAddress, null, null, true, null, out status);

                return status;
            }
        }
    }
}