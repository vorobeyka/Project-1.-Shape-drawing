using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.Data.Exceptions
{
    public class UnexpectedDrawItemException : Exception
    {
        public UnexpectedDrawItemException()
        {
        }

        public UnexpectedDrawItemException(string message) : base(message)
        {
        }
    }
}
