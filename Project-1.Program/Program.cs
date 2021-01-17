using System;
using Project_1.Data;

namespace Programm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var circle = new Circle(new Location(0, 0), 5);
            circle.Draw();
        }
    }
}
