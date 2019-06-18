using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWeb.Services
{
    public interface IHashService
    {
        string Hash(string stringToHash);
    }
}
