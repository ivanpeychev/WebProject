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
    }
}