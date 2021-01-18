using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.Data
{
    class Rectangle : Shape
    {
        private int FirstSide { get; }
        private int SecondSide { get; }

        public Rectangle(int? firstSide, int? secondSide)
        {
            FirstSide = firstSide ?? throw new ArgumentNullException(nameof(firstSide));
            SecondSide = secondSide ?? throw new ArgumentNullException(nameof(secondSide));
            Area = (double)(firstSide * secondSide);
        }
    }
}
