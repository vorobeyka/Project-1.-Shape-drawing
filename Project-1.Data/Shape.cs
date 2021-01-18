using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.Data
{
    public abstract class Shape
    {
        public Location Location { get; }

        public char? DrawItem { get; }

        public Shape(Location location)
        {
            Location = location;
        }

        public abstract double GetArea();

        public abstract double GetPerimeter();

        public abstract void Draw();
    }
}
