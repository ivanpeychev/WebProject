using System.Collections.Generic;

namespace HTTP.Cookies.Contracts
{
    public interface IHttpCookiesCollection : IEnumerable<HttpCookie>
    {
        void Add(HttpCookie httpCookie);
        HttpCookie GetCookie(string key);
        bool ContainsCookie(string key);
        bool HasCookies();
    }
}
