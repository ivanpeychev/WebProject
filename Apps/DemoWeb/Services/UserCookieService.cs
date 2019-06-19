namespace DemoWeb.Services.Contracts
{
    public class UserCookieService : IUserCookieService
    {
        public string GetUserCookie(string userName)
        {
            return EncryptionService.EncryptString(userName);
        }
        public string GetUserData(string cookieContent)
        {
            return EncryptionService.DecryptString(cookieContent);
        }
    }
}
