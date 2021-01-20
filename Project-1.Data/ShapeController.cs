using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Linq;
using Project_1.Data.Exceptions;

namespace Project_1.Data
{
    public static class ShapeController
    {
        private static readonly string _filePath = "cache.json";

        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static void DeleteShape(int id)
        {
            var shapes = GetShapes() ?? throw new ShapeNullException("Empty shapes list");
            var deletedShape = shapes.Find(x => x.Id == id) ?? throw new ShapeNullException(id.ToString());
            Console.WriteLine(deletedShape);
            Console.Write("Do you want to delete? (y) \n-> ");
            if (IsUnswerYes())
            {
                shapes.Remove(deletedShape);
                UpdateCache(shapes);
            }
        }

        public static void CreateLine()
        {
            Console.Write("Enter line length:\n-> ");
            var length = int.Parse(Console.ReadLine());
            var drawItem = GetDrawItem();
            Console.Write("\nIs vertical direction? (y)\n-> ");
            var isVerticalDirection = IsUnswerYes();
            var line = new Line(drawItem, true, length, isVerticalDirection);
            UpdateCache(line);
        }

        public static void CreateTriangle()
        {
            Console.Write("Enter triangle height:\n-> ");
            var height = int.Parse(Console.ReadLine());
            var drawItem = GetDrawItem();
            Console.Write("\nIs fill shape? (y):\n->");
            var isFill = IsUnswerYes();
            var triangle = new Triangle(drawItem, isFill, height);
            UpdateCache(triangle);
        }

        public static void CreateRectangle()
        {
            Console.Write("Enter horizontal side:\n-> ");
            var horizontalSide = int.Parse(Console.ReadLine());
            Console.Write("Enter vertical side:\n-> ");
            var verticalSide = int.Parse(Console.ReadLine());
            var drawItem = GetDrawItem();
            Console.Write("\nIs fill shape? (y):\n->");
            var isFill = IsUnswerYes();
            var rectangle = new Rectangle(drawItem, isFill, horizontalSide, verticalSide);
            UpdateCache(rectangle);
        }

        public static void CreateCircle()
        {
            Console.Write("Enter radius:\n-> ");
            var radius = int.Parse(Console.ReadLine());
            var drawItem = GetDrawItem();
            Console.Write("\nIs fill shape? (y):\n->");
            var isFill = IsUnswerYes();
            var circle = new Circle(drawItem, isFill, radius);
            UpdateCache(circle);
        }

        private static char GetDrawItem()
        {
            Console.Write("Enter drawing item (whitespace forbidden):\n-> ");
            var item = Console.ReadKey().KeyChar;
            return item;
        }

        public static bool IsUnswerYes()
        {
            var key = Console.ReadKey().KeyChar;
            var isFill = key == 'y' || key == 'Y';
            return isFill;
        }

        private static void UpdateCache(Shape newShape)
        {
            var shapes = GetShapes() ?? new List<Shape>();
            shapes.Add(newShape);
            var json = JsonSerializer.Serialize(shapes, _options);
            File.WriteAllText(_filePath, json);
        }

        private static void UpdateCache(List<Shape> shapes)
        {
            var json = JsonSerializer.Serialize(shapes, _options);
            File.WriteAllText(_filePath, json);
        }

        public static List<Shape> GetShapes()
        {
            try
            {
                var json = File.ReadAllText(_filePath);
                var clone = JsonSerializer.Deserialize<List<Shape>>(json);
                return clone;
            }
            catch (Exception)
            {
                throw new ShapeListNullException();
            }
        }
        
        public static Shape GetShapeById(int id)
        {
            var shape = GetShapes()?.Find(x => x.Id == id) ?? throw new ShapeNullException(id.ToString()); ;
            return shape;
        }

        public static List<Shape> GetSortoedShapes()
        {
            Console.Write("Sort by:\n1. Id asceding\n2. Id descending\n3. Perimeter asceding\n" +
                              "4. Perimeter descending\n5. Area asceding\n6. Area descenging\n-> ");
            var key = Console.ReadKey().KeyChar;
            var shapes = GetShapes() ?? throw new ShapeListNullException();
            Console.WriteLine();
            switch (key)
            {
                case '1': return shapes.OrderBy(x => x.Id).ToList();
                case '2': return shapes.OrderByDescending(x => x.Id).ToList();
                case '3': return shapes.OrderBy(x => x.Perimeter).ToList();
                case '4': return shapes.OrderByDescending(x => x.Perimeter).ToList();
                case '5': return shapes.OrderBy(x => x.Area).ToList();
                case '6': return shapes.OrderByDescending(x => x.Area).ToList();
                default: throw new MenuArgumentException();
            }
        }

        public static int? GetMaxId() => GetShapes()?.Select(p => p.Id).Max();
    }
}
