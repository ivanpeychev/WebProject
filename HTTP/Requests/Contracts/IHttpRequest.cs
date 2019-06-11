using HTTP.Cookies.Contracts;
using HTTP.Enums;
using HTTP.Headers.Contracts;
using HTTP.Sessions.Contracts;
using System.Collections.Generic;

namespace HTTP.Requests.Contracts
{
    public interface IHttpRequest
    {
        string Path { get; }
        string Url { get; }
        Dictionary<string, object> FormData { get; }
        Dictionary<string, object> QueryData { get; }
        IHttpHeaderCollection Headers { get; }
        IHttpCookiesCollection Cookies { get; }
        HttpRequestMethod RequestMethod { get; }
        IHttpSession Session { get; set; }
    }
}
