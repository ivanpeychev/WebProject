using DemoWeb.Data;
using HTTP.Responses.Contracts;
using Server.Results;
using System.IO;
using System.Net;

namespace DemoWeb.Controllers
{
    public abstract class BaseController
    {
        protected EfDbContext Db { get; set; }
        protected BaseController()
        {
            this.Db = new EfDbContext();
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
