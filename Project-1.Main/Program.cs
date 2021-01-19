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

        static void CreateShape()
        {
            Console.WriteLine("Create shape.");
            while (true)
            {
                Console.WriteLine("Create shape.");
                Console.Write("1. Line\n2. Triangle\n3. Rectangle\n4. Circle\n5. Back\n-> ");
                var key = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (key)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5': return;
                    default:
                        Console.WriteLine("Error: invalid menu number");
                        break;
                }
            }
        }


        static void ColorSettings()
        {
            var settings = new Settings();
            while (true)
            {
                Console.WriteLine("Color settings.");
                Console.Clear();
                Console.WriteLine("Error: text color and background color can't be equal");
            }
            settings.BackgroundColor = (int)Console.BackgroundColor;
            settings.TextColor = (int)Console.ForegroundColor;
            var json = JsonSerializer.Serialize(settings);
            File.WriteAllText("settings.json", json);
        }
        static void Main(string[] args)
        {

        }
    }   
}