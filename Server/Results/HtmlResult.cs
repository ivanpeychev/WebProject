using HTTP.Headers;
using HTTP.Responses;
using System.Net;
using System.Text;

namespace Server.Results
{
    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpStatusCode statusCode)
            : base(statusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/html"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
