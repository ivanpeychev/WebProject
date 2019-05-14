using System;
using System.Collections.Generic;
using System.Text;

namespace HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        private new const string Message = "The Request was malformed or contains unsupported elements.";
        public BadRequestException() 
            :base(Message)
        {

        }
    }
}
