using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.Data
{
    public class Rectangle : Shape
    {
        private int HorizontalSide { get; }
        private int VerticalSide { get; }

        public Rectangle(char? drawItem, bool isFill, int? horizontalSide, int? verticalSide) : base(drawItem, isFill)
        {
            if (horizontalSide <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(horizontalSide));
            }
            if (verticalSide <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(verticalSide));
            }
            HorizontalSide = horizontalSide ?? throw new ArgumentNullException(nameof(horizontalSide));
            VerticalSide = verticalSide ?? throw new ArgumentNullException(nameof(verticalSide));
            Area = HorizontalSide * VerticalSide;
            Perimeter = 2 * HorizontalSide + 2 * VerticalSide;
            CreateRectangle();
        }

        private void CreateRectangle()
        {
            ShapeMatrix = new char[VerticalSide][];
            for (int i = 0; i < VerticalSide; i++)
            {
                var line = new char[HorizontalSide];
                for (int j = 0; j < HorizontalSide; j++)
                {
                    if (i == 0 || i == VerticalSide - 1 || IsFill || j == 0 || j == HorizontalSide - 1)
                    {
                        line[j] = DrawItem;
                    }
                    else
                    {
                        line[j] = ' ';
                    }
                }
                ShapeMatrix[i] = line;
            }
        }
    }
}
