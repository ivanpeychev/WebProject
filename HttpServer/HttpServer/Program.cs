using System;
using System.Collections.Generic;

namespace HttpServer
{
    class Program
    {
        static void Main()
        {
            //IHttpServer server = new HttpServer();
            //server.Start();

            AddRoute("users/get");
            AddRoute("users/delete");
            AddRoute("dealers/put");
            AddRoute("dealers/get");
            AddRoute("dealers/post");

            ListRoutes();

            ParseRequest("dealers/get");
        }

        static Dictionary<string, HashSet<string>> routeActions = new Dictionary<string, HashSet<string>>();
        public static void AddRoute(string newRoute)
        {
            var tokens = newRoute.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 2)
            {
                var route = tokens[0];
                var action = tokens[1];

                if (!routeActions.ContainsKey(route))
                {
                    routeActions.Add(route, new HashSet<string>());
                }

                routeActions[route].Add(action);
            }
        }
        private static void ListRoutes()
        {
            foreach (var route in routeActions)
            {
                Console.WriteLine(route.Key);
                foreach (var action in route.Value)
                {
                    Console.WriteLine("  " + action);
                }
                Console.WriteLine();
            }
        }
        public static void ParseRequest(string request)
        {
            Console.WriteLine(request);
            Console.WriteLine();
            var tokens = request.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 2)
            {
                var route = tokens[0];
                var action = tokens[1];

                if (routeActions.ContainsKey(route))
                {
                    if (routeActions[route].Contains(action))
                    {
                        Console.WriteLine("Cool, valid route and action.");
                    }
                    else
                    {
                        throw new Exception("The action doesn't exist!");
                    }
                }
                else
                {
                    throw new Exception("The route doesn't exist!");
                }
            }
            else
            {
                throw new Exception("Invalid request!");
            }
        }
    }
}