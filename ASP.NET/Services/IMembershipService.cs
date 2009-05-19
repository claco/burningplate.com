using System.Web.Security;

namespace BurningPlate.Services
{
    public interface IMembershipService
    {
        bool ValidateUser(string userName, string password);

        MembershipCreateStatus CreateUser(string userName, string password, string emailAddress);
    }
}