using System;
using System.Collections.Generic;
using System.Text;

namespace HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException(string message = "The Server has encountered an error.") : base(message)
        {

        }
    }
}
