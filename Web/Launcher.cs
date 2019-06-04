using HTTP.Enums;
using Server.Routing;

namespace Web
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.GET]["/"] = request => new HomeController().Index();

            Server.Server server = new Server.Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
