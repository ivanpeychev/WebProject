using HTTP.Responses.Contracts;
using Server.Results;
using System.IO;
using System.Net;

namespace DemoWeb.Controllers
{
    public abstract class BaseController
    {
        protected IHttpResponse View(string viewName)
        {
            var content = File.ReadAllText($"Views/{viewName}.html");
            return new HtmlResult(content, HttpStatusCode.OK);
        }
    }
}
