using HTTP.Cookies;
using HTTP.Cookies.Contracts;
using HTTP.Enums;
using HTTP.Headers;
using HTTP.Headers.Contracts;
using System.Net;

namespace HTTP.Responses.Contracts
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; set; }
        IHttpHeaderCollection Headers { get; }
        byte[] Content { get; set; }
        void AddHeader(HttpHeader header);
        IHttpCookiesCollection Cookies { get; }
        void AddCookie(HttpCookie HttpCookie);
        byte[] GetBytes();
    }
}
