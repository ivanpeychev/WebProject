using System;

namespace HttpServer
{
    class Program
    {
        static void Main()
        {
            IHttpServer server = new HttpServer();
            server.Start();
        }
    }
}