using System;
using System.Collections.Generic;
using System.Text;

namespace HTTP.Headers.Contracts
{
    interface IHttpHeaderCollection
    {
        void Add(HttpHeader header);
        bool ContainsHeader(string key);
        HttpHeader GetHeader(string key);
    }
}
