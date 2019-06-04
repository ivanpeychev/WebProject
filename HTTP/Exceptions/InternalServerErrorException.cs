using System;
using System.Collections.Generic;
using System.Text;

namespace HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private new const string Message = "The Server has encountered an error.";
        public InternalServerErrorException() 
            :base(Message)
        {

        }
    }
}
