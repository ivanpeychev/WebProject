using System;
using System.Collections.Generic;
using System.Text;

namespace HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message = "The Request was malformed or contains unsupported elements.") : base(message)
        {

        }
    }
}
