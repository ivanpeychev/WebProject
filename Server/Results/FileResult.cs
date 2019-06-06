using HTTP.Headers;
using HTTP.Responses;
using System.Net;
using System.Text;

namespace Server.Results
{
    public class FileResult : HttpResponse
    {
        public FileResult(byte[] content, HttpStatusCode statusCode)
            : base(statusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "application/octet-stream"));
            this.Headers.Add(new HttpHeader("Content-Disposition", "attachment; filename=Document.docx"));

            this.Content = content;
        }
    }
}
