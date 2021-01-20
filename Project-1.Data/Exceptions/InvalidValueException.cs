using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.Data.Exceptions
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException()
        {
        }

        public InvalidValueException(string message) : base(message)
        {
        }
    }
}
