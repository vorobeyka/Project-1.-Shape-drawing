using System;
using System.Threading;
using Project_1.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;

namespace Project_1.Main
{
    class Program
    {
        static void SearchShape()
        {
            Console.WriteLine("Search shape.");
            Console.Write("Enter filter:\n-> ");
            var filter = Console.ReadLine();

        }

        static void ViewShape()
        {
            Console.WriteLine("View shape.");
        }

        static void CreateShape()
        {
            Console.WriteLine("Create shape.");
        }

        static void EditShape()
        {
            Console.WriteLine("Edit shape.");
        }

        static void DeleteShape()
        {
            Console.WriteLine("Delete shape.");
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
            var settings = new Settings();
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
                    Console.Clear();
                    Console.WriteLine("Error: text color and background color can't be equal");
                }
                settings.BackgroundColor = (int)Console.BackgroundColor;
                settings.TextColor = (int)Console.ForegroundColor;
                var json = JsonSerializer.Serialize(settings);
                File.WriteAllText("settings.json", json);
            }
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Menu:\n1. Search shape.\n2. View shape\n3. Create shape\n4. Edit Shape\n5. Delete shape\n6. Color settings\n7. Exit");
                Console.Write("-> ");
                var key = Console.ReadKey().KeyChar;
                Console.Clear();
                try
                {
                    switch (key)
                    {
                        case '1': SearchShape();
                            break;
                        case '2': ViewShape();
                            break;
                        case '3': CreateShape();
                            break;
                        case '4': EditShape();
                            break;
                        case '5': DeleteShape();
                            break;
                        case '6': ColorSettings();
                            break;
                        case '7': Console.WriteLine("Bye!");
                            return;
                        default: Console.WriteLine("Invalid menu number. Try again");
                            break;
                    }
                }
                catch (Exception) { }
            }
        }

        static void Main(string[] args)
        {
            /*try
            {
                var json = File.ReadAllText("settings.json");
                var clone = JsonSerializer.Deserialize<Settings>(json);
                if (clone == null)
                {
                    throw new ArgumentNullException();
                }
                Console.ForegroundColor = (ConsoleColor)(clone.TextColor ?? throw new ArgumentNullException());
                Console.BackgroundColor = (ConsoleColor)(clone.BackgroundColor ?? throw new ArgumentNullException());
            }
            catch (Exception) { }*/

            /*string[] arr = {
                "Project_1. Shape drawing by Andrey Basystyi.",
                "This program can draw shapes with some customization.",
                "Enjoy"
            };
            foreach (var i in arr)
            {
                foreach (var j in i)
                {
                    Console.Write(j);
                    Thread.Sleep(100);
                }
                Thread.Sleep(1500);
                Console.Clear();
            }*/
            //Console.WriteLine("Project_1. Shape drawing by Andrey Basystyi.");
            //Console.WriteLine("This program can draw shapes with some customization.");
            //int[][] arr = new int[2][];
            //arr[0] = new int[3] { 1, 2, 3 };
            //arr[1] = new int[3] { 1, 2, 5 };
            //List<Circle> shapes = new List<Circle>();
            //shapes.Add(new Circle(new Location(1, 1), 5));
            //var jjson = JsonSerializer.Serialize(arr);
            //File.WriteAllText("cache.json", jjson);
            //var circle = new Circle(5, false);
            //var json = JsonSerializer.Serialize(circle);
            //File.WriteAllText("cache.json", json);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = File.ReadAllText("cache.json");
            var clone = JsonSerializer.Deserialize<Shape>(json, options);
            Console.WriteLine(clone);
            ///Menu();
        }
    }
}
