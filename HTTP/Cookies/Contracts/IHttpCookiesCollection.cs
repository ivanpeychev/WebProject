namespace HTTP.Cookies.Contracts
{
    public interface IHttpCookiesCollection
    {
        void Add(HttpCookie httpCookie);
        HttpCookie GetCookie(string key);
        bool ContainsCookie(string key);
        bool HasCookies();
    }
}
