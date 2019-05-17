﻿using HTTP.Enums;
using HTTP.Headers.Contracts;
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
        HttpRequestMethod RequestMethod { get; }
    }
}