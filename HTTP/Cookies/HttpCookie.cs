﻿using System;
namespace HTTP.Cookies
{
    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationDays = 3;

        public HttpCookie(string key, string value, int expirationDays = HttpCookieDefaultExpirationDays)
        {
            this.Key = key;
            this.Value = value;
            this.Expires = DateTime.UtcNow.AddDays(expirationDays);
            this.IsNew = true;
        }
        public HttpCookie(string key, string value, bool isNew, int expirationDays = HttpCookieDefaultExpirationDays)
            : this(key, value, expirationDays)
        {
            this.IsNew = isNew;
        }
        public string Key { get; }
        public string Value { get; }
        public DateTime Expires { get; }
        public bool IsNew { get; }
        public override string ToString()
        {
            return $"{this.Key}={this.Value}";
        }
    }
}
