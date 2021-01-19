using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Project_1.Data.Exceptions;

namespace Project_1.Data
{
    public class Shape
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("perimeter")]
        public double Perimeter { get; set; }
        [JsonPropertyName("area")]
        public double Area { get; set; }
        [JsonPropertyName("shape")]
        public char[][] ShapeMatrix { get; set; }
        
        protected char DrawItem { get; }
        protected bool IsFill { get; }

        public Shape() { }

        public Shape(char? drawItem, bool isFill)
        {
            if (drawItem < 33 || drawItem > 126)
            {
                throw new UnexpectedDrawItemException();
            }
            DrawItem = drawItem ?? throw new ArgumentNullException(nameof(drawItem));
            IsFill = isFill;
            Id = ShapeController.GetMaxId() + 1 ?? 1;
        }

        public override string ToString()
        {
            var res = $"Id: {Id}\nPerimeter: {Math.Round(Perimeter, 4)}\nArea: {Math.Round(Area, 4)}\n";
            for (int i = 0; i < ShapeMatrix.Length; i++)
            {
                foreach (var j in ShapeMatrix[i])
                {
                    res += j;
                }
                if (i + 1 != ShapeMatrix.Length)
                {
                    res += '\n';
                }
            }
            return res;
        }
    }
}
