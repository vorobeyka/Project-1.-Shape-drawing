using System;
using System.Threading;
using Project_1.Data;
using Project_1.Data.Exceptions;

namespace Programm
{
    class Program
    {
        static void ConsoleWait()
        {
            Console.WriteLine("Press eny key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        static void PrintError(string message)
        {
            Console.Clear();
            Console.WriteLine($"Error: {message}");
        }

        static void SearchShape()
        {
            Console.WriteLine("Search shape.");
            Console.Write("Enter shape id\n-> ");
            var id = int.Parse(Console.ReadLine());
            var shape = ShapeController.GetShapeById(id);
            Console.WriteLine(shape);
            ConsoleWait();
        }

        static void ViewShape()
        {
            Console.WriteLine("View shapes.");
            var shapes = ShapeController.GetSortoedShapes();
            Console.Clear();
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }
            ConsoleWait();
        }

        static void ShapesGallery()
        {
            var shapes = ShapeController.GetSortoedShapes();
            var flag = true;
            for (int i = 0; flag; )
            {
                Console.Clear();
                Console.WriteLine("Shapes gallery.");
                Console.WriteLine(shapes[i]);
                Console.WriteLine("Navigation:\n> - next page\n< - previous page\nq - back to menu");
                var key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '.':
                    case '>': if (i != shapes.Count - 1) i++;
                        break;
                    case ',':
                    case '<': if (i != 0) i--;
                        break;
                    case 'q': flag = false;
                        break;
                    default: continue;
                }
            }
            Console.Clear();
        }

        static void CreateShape()
        {
            Console.WriteLine("Create shape.");
            Console.Write("1. Line\n2. Triangle\n3. Rectangle\n4. Circle\n5. Return to menu\n-> ");
            var key = Console.ReadKey().KeyChar;
            Console.Clear();
            switch (key)
            {
                case '1': ShapeController.CreateLine();
                    break;
                case '2': ShapeController.CreateTriangle();
                    break;
                case '3': ShapeController.CreateRectangle();
                    break;
                case '4': ShapeController.CreateCircle();
                    break;
                case '5': return;
                default: throw new MenuArgumentException();
            }
            Console.Clear();
        }

        static void DeleteShape()
        {
            Console.WriteLine("Delete shape.");
            Console.Write("Enter shape id\n-> ");
            var id = int.Parse(Console.ReadLine());
            ShapeController.DeleteShape(id);
            Console.Clear();
        }

        static ConsoleColor ChangedColor()
        {
            Console.Write("0. Black\n1. Dark blue\n2. Dark green\n3. Dark Cyan\n4. Dark red\n5. Dark magenta\n6. Dark yellow" +
                              "\n7. Gray\n8. Dark gray\n9. Blue\n-> ");
            var key = Console.ReadKey().KeyChar - 48;
            Console.Clear();
            if (key > 12 || key < 0)
            {
                Console.WriteLine("Error: invalid menu number");
                return ChangedColor();
            }
            return (ConsoleColor)key;
        }

        static void ColorSettings()
        {
            while (true)
            {
                Console.WriteLine("Color settings.");
                Console.Write("1. Change text color\n2. Change background color\n3. Back\n-> ");
                var key = Console.ReadKey().KeyChar;
                var bgColor = Console.BackgroundColor;
                var textColor = Console.ForegroundColor;
                Console.Clear();
                switch (key)
                {
                    case '1':
                        Console.ForegroundColor = ChangedColor();
                        Console.Clear();
                        break;
                    case '2':
                        Console.BackgroundColor = ChangedColor();
                        Console.Clear();
                        break;
                    case '3': return;
                    default:
                        Console.WriteLine("Invalid menu number. Try again");
                        break;
                }
                if (Console.BackgroundColor == Console.ForegroundColor)
                {
                    Console.BackgroundColor = bgColor;
                    Console.ForegroundColor = textColor;
                    throw new Exception("Error: text color and background color can't be equal");
                }
            }
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Menu:\n1. Create shape\n2. Search shape\n3. View shapes\n" +
                                  "4. Shapes gallery\n5. Delete shape\n6. Colors settings\n7. Exit");
                Console.Write("-> ");
                var key = Console.ReadKey().KeyChar;
                Console.Clear();
                try
                {
                    switch (key)
                    {
                        case '1':
                            CreateShape();
                            break;
                        case '2':
                            SearchShape();
                            break;
                        case '3':
                            ViewShape();
                            break;
                        case '4':
                            ShapesGallery();
                            break;
                        case '5':
                            DeleteShape();
                            break;
                        case '6':
                            ColorSettings();
                            break;
                        case '7':
                            Console.WriteLine("Bye!");
                            return;
                        default: throw new MenuArgumentException();
                    }
                }
                catch (MenuArgumentException)
                {
                    PrintError("Invalid menu number.");
                }
                catch (ShapeNullException ex)
                {
                    PrintError($"Not find shape with id {ex.Message}.");
                }
                catch (ShapeListNullException)
                {
                    PrintError("Empty shapes list.");
                }
                catch (UnexpectedDrawItemException)
                {
                    PrintError("Unexpected draw item.");
                }
                catch (Exception ex)
                {
                    PrintError($"{ex.Message}");
                }
            }
        }

        static void Main(string[] args)
        {
            string[] arr = {
                "Project_1. Shape drawing by Andrey Basystyi.",
                "This program can draw shapes with some customization.",
                "Enjoy"
            };
            /*foreach (var i in arr)
            {
                foreach (var j in i)
                {
                    Console.Write(j);
                    Thread.Sleep(100);
                }
                Thread.Sleep(1500);
                Console.Clear();
            }*/
            Menu();
        }
    }
}
