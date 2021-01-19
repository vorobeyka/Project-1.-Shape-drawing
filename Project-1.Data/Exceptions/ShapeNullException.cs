using System;

namespace Project_1.Data.Exceptions
{
    public class ShapeNullException : Exception
    {
        public ShapeNullException()
        {
        }

        public ShapeNullException(string message) : base(message)
        {
        }
    }
}
