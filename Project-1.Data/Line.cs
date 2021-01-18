using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.Data
{
    class Line : Shape
    {
        private int Length { get; }

        public Line(int? length, bool isUp)
        {
            Length = length ?? throw new ArgumentNullException(nameof(length));
            Perimeter = Length;
            Area = Length;
        }
    }
}
