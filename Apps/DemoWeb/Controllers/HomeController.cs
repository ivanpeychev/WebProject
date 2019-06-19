using HTTP.Responses.Contracts;
using System.Net;
using Server.Results;
using DemoWeb.Controllers;
using HTTP.Requests.Contracts;

namespace DemoWeb
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View("Index");
        }

        public IHttpResponse HelloUser(IHttpRequest request)
        {
            return new HtmlResult($"<h3>Hello, {this.GetUserName(request)}!</h3>", HttpStatusCode.OK);
        }
    }
}