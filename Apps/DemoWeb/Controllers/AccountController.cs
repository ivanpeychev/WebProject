using HTTP.Responses.Contracts;
using Server.Results;
using DemoWeb.Controllers;
using HTTP.Requests.Contracts;
using System.Linq;
using DemoWeb.Services.Contracts;
using DemoWeb.Services;
using DemoWeb.Models;
using System;
using HTTP.Cookies;
using DemoWeb.Common;

namespace DemoWeb
{
    public class AccountController : BaseController
    {
        private IHashService hashService;
        public AccountController()
        {
            this.hashService = new HashService();
        }
        public IHttpResponse Register()
        {
            return this.View("Register");
        }
        public IHttpResponse DoRegister(IHttpRequest request)
        {
            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword= request.FormData["confirmPassword"].ToString();

            // Validate
            if (string.IsNullOrEmpty(userName) || userName.Length < 5)
            {
                return this.BadRequestError("Please provide a valid username with length at least 5 characters.");
            }

            if (string.IsNullOrEmpty(password) || password.Length < 5)
            {
                return this.BadRequestError("Please provide a password with length at least 5 characters.");
            }

            if (this.Db.Users.Any(u => u.Username == userName))
            {
                return this.BadRequestError("A user with the same username already exists.");
            }

            if (confirmPassword != password)
            {
                return this.BadRequestError("Passwords do not match.");
            }

            // Hash
            var hashedPassword = this.hashService.Hash(password);

            // Create user
            var user = new User()
            {
                Username = userName,
                Password = hashedPassword
            };
            this.Db.Users.Add(user);
            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: Log error
                return this.ServerError(ex.Message);
            }

            return new RedirectResult("/");
        }
        public IHttpResponse Login()
        {
            return this.View("Login");
        }
        public IHttpResponse DoLogin(IHttpRequest request)
        {
            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();

            var hashedPassword = this.hashService.Hash(password);

            if (!this.Db.Users.Any(u => u.Username == userName && u.Password == hashedPassword))
            {
                this.BadRequestError("Invalid username or password.");
            }

            var cookieContent = this.UserCookieService.GetUserCookie(userName);
            var response = new RedirectResult("/");
            response.Cookies.Add(new HttpCookie(GlobalConstants.AuthorizationCookieKey, cookieContent, 7));

            return response;
        }
        public IHttpResponse Logout(IHttpRequest request)
        {
            var response = new RedirectResult("/");

            if (request.Cookies.ContainsCookie(GlobalConstants.AuthorizationCookieKey));
            {
                var cookie = request.Cookies.GetCookie(GlobalConstants.AuthorizationCookieKey);
                cookie.Delete();
                response.AddCookie(cookie);
            }

            return response;
        }
    }
}
