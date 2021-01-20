using System;
using System.Collections.Generic;
using Project_1.Data.Exceptions;

namespace Project_1.Data
{
    public class Triangle : Shape
    {
        private int Height { get; }

        public Triangle(char? drawItem, bool isFill, int height) : base(drawItem, isFill)
        {
            if (height <= 0)
            {
                throw new InvalidValueException("height");
            }
            Height = height;
            Perimeter = Height * 3;
            Area = Math.Sqrt(3) * Math.Pow(Height, 2) / 4;

            CreateTriangle();
        }

        private void CreateTriangle()
        {
            ShapeMatrix = new char[Height][];
            
            for (int i = 0; i < Height; i++)
            {
                var line = new List<char>();
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i || i == Height - 1 || IsFill)
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
