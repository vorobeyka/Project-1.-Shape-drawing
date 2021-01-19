using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.Data
{
    public class Line : Shape
    {
        private int Length { get; }

        public Line(char? drawItem, bool isFill, int? length, bool isVerticalDirection) : base(drawItem, isFill)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            Length = length ?? throw new ArgumentNullException(nameof(length));
            Perimeter = Length;
            Area = Length;

            CreateLine(isVerticalDirection);
        }

        private void CreateLine(bool isVerticalDirection)
        {
            if (isVerticalDirection)
            {
                ShapeMatrix = new char[Length][];
                for (int i = 0; i < Length; i++)
                {
                    var line = new char[1];
                    line[0] = DrawItem;
                    ShapeMatrix[i] = line;
                }
            }
            else
            {
                ShapeMatrix = new char[1][];
                var line = new char[Length];
                for (int i = 0; i < Length; i++)
                {
                    line[i] = DrawItem;
                }
                ShapeMatrix[0] = line;
            }
        }
    }
}
