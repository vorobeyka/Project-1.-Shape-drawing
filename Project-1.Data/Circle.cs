using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.Data
{
    public class Circle : Shape
    {
        private int Radius { get; }

        public Circle(char? drawItem, bool isFill, int? radius) : base(drawItem, isFill)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius));
            }
            Radius = radius ?? throw new ArgumentNullException(nameof(radius));
            Perimeter = 2 * Math.PI * Radius;
            Area = Math.PI * Math.Pow(Radius, 2);
            CreateCircle();
        }

        private void CreateCircle()
        {
            ShapeMatrix = new char[Radius * 2 + 1][];
            var inRadius = Radius - 0.4;
            var outRadius = Radius + 0.4;
            var y = Radius;

            for (int i = 0; y >= -Radius; y--, i++)
            {
                var line = new List<char>();
                for (double x = -Radius; x < outRadius; x+=0.5)
                {
                    var value = x * x + y * y;
                    if (value >= inRadius * inRadius && value <= outRadius * outRadius)
                    {
                        line.Add(DrawItem);
                    }
                    else if (IsFill && value < inRadius * inRadius && value < outRadius * outRadius)
                    {
                        line.Add(DrawItem);
                    }
                    else
                    {
                        line.Add(' ');
                    }
                }
                ShapeMatrix[i] = line.ToArray();
            }
        }
    }
}
