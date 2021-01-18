using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.Data
{
    [Serializable]
    public class Circle : Shape
    {
        private int Radius { get; }
        private bool IsFill { get; }

        public Circle(int? radius, bool isFill)
        {
            Radius = radius ?? throw new ArgumentNullException(nameof(radius));
            Perimeter = 2 * Math.PI * Radius;
            Area = Math.PI * Math.Pow(Radius, 2);
            IsFill = isFill;

            ShapeMatrix = new char[Radius * 2 + 1][];
            var r_in = Radius - 0.5;
            var r_out = Radius + 0.5;
            var y = Radius;

            for (int i = 0; y >= -Radius; y--, i++)
            {
                var line = new List<char>();
                for (double x = -Radius; x < r_out; x += 0.5)
                {
                    var value = x * x + y * y;
                    if (value >= r_in * r_in && value <= r_out * r_out)
                    {
                        line.Add('@');
                    }
                    else if (IsFill && value < r_in * r_in && value < r_out * r_out)
                    {
                        line.Add('@');
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
