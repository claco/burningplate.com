namespace BurningPlate.Services
{
    public interface IAuthenticationService
    {
        void SignIn(string userName, bool remember);

        void SignOut();
    }
}