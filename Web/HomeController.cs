using HTTP.Responses.Contracts;
using System.Net;
using Server.Results;

namespace Web
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>Hello, World!</h1>";

            return new HtmlResult(content, HttpStatusCode.OK);
        }
    }
}
