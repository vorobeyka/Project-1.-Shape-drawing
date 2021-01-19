using System;

namespace Project_1.Data.Exceptions
{
    public class ShapeListNullException : Exception
    {
        public ShapeListNullException()
        {
        }

        public ShapeListNullException(string message) : base(message)
        {
        }
    }
}
