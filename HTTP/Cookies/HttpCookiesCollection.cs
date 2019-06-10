using HTTP.Cookies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTTP.Cookies
{
    public class HttpCookiesCollection : IHttpCookiesCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;
        public HttpCookiesCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }
        public void Add(HttpCookie httpCookie)
        {
            if (httpCookie == null)
            {
                throw new ArgumentNullException();
            }

            if (!this.ContainsCookie(httpCookie.Key))
            {
                this.cookies.Add(httpCookie.Key, httpCookie);
            }
            else
            {
                this.cookies[httpCookie.Key] = httpCookie;
            }
        }
        public bool ContainsCookie(string key)
        {
            if (this.cookies.Keys.Contains(key))
            {
                return true;
            }
            return false;
        }
        public HttpCookie GetCookie(string key)
        {
            return this.cookies[key];
        }
        public bool HasCookies()
        {
            return this.cookies.Any();
        }
        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }
    }
}
