using HTTP.Responses.Contracts;
using System.Net;
using Server.Results;

namespace DemoWeb
{
    public class DownloadController
    {
        public IHttpResponse Index()
        {
            byte[] content = System.IO.File.ReadAllBytes("file.docx");

            return new FileResult(content, HttpStatusCode.OK);
        }
    }
}
