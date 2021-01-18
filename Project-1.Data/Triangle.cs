using System;
using System.Collections.Generic;
using System.Text;

namespace Project_1.Data
{
    class Triangle : Shape
    {
        private int FirstSide { get; }
        private int SecondSide { get; }
        private int ThirdSide { get; }

        public Triangle(int? firstSide, int? secondSide)
        {
            FirstSide = firstSide ?? throw new ArgumentNullException(nameof(firstSide));
            SecondSide = secondSide ?? throw new ArgumentNullException(nameof(secondSide));
            Perimeter = FirstSide + SecondSide;
            var p = Perimeter / 2;
            Area = Math.Sqrt(p * (p - FirstSide) * (p - SecondSide) * (p - ThirdSide));
        }
    }
}
