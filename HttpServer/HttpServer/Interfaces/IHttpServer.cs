using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer
{
    interface IHttpServer
    {
        void Start();

        void Stop();
    }
}
