using HTTP.Common;
using HTTP.Cookies;
using HTTP.Cookies.Contracts;
using HTTP.Enums;
using HTTP.Extensions;
using HTTP.Headers;
using HTTP.Headers.Contracts;
using HTTP.Responses.Contracts;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse() { }
        public HttpResponse(HttpStatusCode statusCode)
        {
            this.Headers = new HttpHeadersCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public byte[] Content { get; set; }

        public IHttpCookiesCollection Cookies { get; }

        public void AddCookie(HttpCookie HttpCookie)
        {
            this.Cookies.Add(HttpCookie);
        }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString())
                .Concat(this.Content)
                .ToArray();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}").Append(Environment.NewLine)
                .Append(this.Headers);

            if (this.Cookies.HasCookies())
            {
                result
                    .AppendLine($"{"Set-Cookie"}: {this.Cookies}")
                    .AppendLine();
            }

            result.AppendLine();

            return result.ToString();
        }
    }
}
