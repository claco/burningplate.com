using System;
using System.Web.Security;

namespace BurningPlate.Services
{
    public class AuthenticationService : IAuthenticationService 
    {
        public void SignIn(string userName, bool remember)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("userName is required");
            } else
            {
               FormsAuthentication.SetAuthCookie(userName, remember);
            }
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}