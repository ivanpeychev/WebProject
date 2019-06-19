using DemoWeb.Common;
using DemoWeb.Data;
using DemoWeb.Services.Contracts;
using HTTP.Requests.Contracts;
using HTTP.Responses.Contracts;
using Server.Results;
using System.IO;
using System.Net;

namespace DemoWeb.Controllers
{
    public abstract class BaseController
    {
        protected EfDbContext Db { get; set; }
        protected IUserCookieService UserCookieService { get; }

        protected BaseController()
        {
            this.Db = new EfDbContext();
            this.UserCookieService = new UserCookieService();
        }

        protected string GetUserName(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(GlobalConstants.AuthorizationCookieKey))
            {
                return null;
            }

            var cookieContent = request.Cookies.GetCookie(GlobalConstants.AuthorizationCookieKey).Value;
            var userName = this.UserCookieService.GetUserData(cookieContent);
            return userName;
        }

        protected IHttpResponse View(string viewName)
        {
            var content = File.ReadAllText($"Views/{viewName}.html");
            return new HtmlResult(content, HttpStatusCode.OK);
        }

        protected IHttpResponse BadRequestError(string errorMessage)
        {
            return new HtmlResult($"<h2>{errorMessage}</h2>", HttpStatusCode.BadRequest);
        }
        protected IHttpResponse ServerError(string errorMessage)
        {
            return new HtmlResult($"<h2>{errorMessage}</h2>", HttpStatusCode.InternalServerError);
        }
    }
}
