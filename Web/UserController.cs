using HTTP.Responses.Contracts;
using System.Net;
using Server.Results;
using System.Collections.Generic;
using System.Text;

namespace DemoWeb
{
    public class UserController
    {
        public IHttpResponse Index()
        {
            var userList = new List<string>()
            {
                "Ivan Ivanov",
                "George Georgiev",
                "Penka Penkova"
            };

            var result = new StringBuilder();

            foreach (var user in userList)
            {
                result.AppendLine($"<li>{user}</li>");
            }

            string content = $"<ul>{result}</ul>";

            return new HtmlResult(content, HttpStatusCode.OK);
        }
    }
}
