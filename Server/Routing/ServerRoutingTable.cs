using HTTP.Enums;
using HTTP.Requests.Contracts;
using HTTP.Responses.Contracts;
using System;
using System.Collections.Generic;

namespace Server.Routing
{
    public class ServerRoutingTable
    {
        public Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>> Routes { get; set; }
        public ServerRoutingTable()
        {
            this.Routes = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>()
            {
                [HttpRequestMethod.GET] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.POST] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.PUT] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.DELETE] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>()
            };
        }
    }
}
