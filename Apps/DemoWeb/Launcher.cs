using HTTP.Enums;
using Server.Routing;

namespace DemoWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.GET]["/"] = request => new HomeController().Index();
            serverRoutingTable.Routes[HttpRequestMethod.GET]["/register"] = request => new AccountController().Register();
            serverRoutingTable.Routes[HttpRequestMethod.GET]["/login"] = request => new AccountController().Login();
            serverRoutingTable.Routes[HttpRequestMethod.GET]["/logout"] = request => new AccountController().Logout(request);
            serverRoutingTable.Routes[HttpRequestMethod.GET]["/hello"] = request => new HomeController().HelloUser(request);
            serverRoutingTable.Routes[HttpRequestMethod.POST]["/register"] = request => new AccountController().DoRegister(request);
            serverRoutingTable.Routes[HttpRequestMethod.POST]["/login"] = request => new AccountController().DoLogin(request);

            Server.Server server = new Server.Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
