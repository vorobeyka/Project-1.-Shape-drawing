using System;

namespace Project_1.Data.Exceptions
{
    public class MenuArgumentException : Exception
    {
        public MenuArgumentException()
        {
        }

        public MenuArgumentException(string message) : base(message)
        {
        }
    }
}
