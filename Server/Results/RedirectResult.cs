using HTTP.Headers;
using HTTP.Responses;
using System.Net;

namespace Server.Results
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            : base(HttpStatusCode.Redirect)
        {
            this.Headers.Add(new HttpHeader("Location", location));
        }
    }
}
