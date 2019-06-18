using HTTP.Responses.Contracts;
using System.Net;
using Server.Results;
using System.Collections.Generic;
using System.Text;
using DemoWeb.Controllers;

namespace DemoWeb
{
    public class AccountController : BaseController
    {
        public IHttpResponse Register()
        {
            return this.View("Register");
        }
    }
}
