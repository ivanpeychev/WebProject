using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpServer
{
    class HttpServer : IHttpServer
    {
        private TcpListener tcpListener;
        private bool isWorking;

		private readonly string newLine = Environment.NewLine;

        public HttpServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
        }
        public void Start()
        {
            this.isWorking = true;
            this.tcpListener.Start();
			Console.WriteLine("Server started.");
            while (this.isWorking)
            {
                var client = this.tcpListener.AcceptTcpClient();
                var stream = client.GetStream();
                var buffer = new byte[10240];
                var readLength = stream.Read(buffer, 0, buffer.Length);
                var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
                Console.WriteLine(new string('=', 60));
                Console.WriteLine(requestText);
				string responseText = File.ReadAllText("index.html");
				var responseBytes = Encoding.UTF8.GetBytes(
					"HTTP/1.0 200 OK" + newLine + 
					"Content-Type: text/html" + newLine +
					"Content-Length: " + responseText.Length +
					newLine + newLine +
					responseText
				);
				stream.Write(responseBytes);
            }
        }

        public void Stop()
        {
            this.isWorking = false;
        }
    }
}
