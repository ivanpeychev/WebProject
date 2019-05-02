using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpServer
{
    class HttpServer : IHttpServer
    {
        private TcpListener tcpListener;
        private bool isWorking;

        public HttpServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
        }
        public void Start()
        {
            this.isWorking = true;
            this.tcpListener.Start();
            while (this.isWorking)
            {
                var client = this.tcpListener.AcceptTcpClient();
                var stream = client.GetStream();
                var buffer = new byte[10240];
                var readLength = stream.Read(buffer, 0, buffer.Length);
                var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
                Console.WriteLine(new string('=', 60));
                Console.WriteLine(requestText);
            }
        }

        public void Stop()
        {
            this.isWorking = false;
        }
    }
}
