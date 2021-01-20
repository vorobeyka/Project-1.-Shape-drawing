using System;
using System.Threading;

namespace Project_1.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            SettingsController.LoadSettings();
            Console.Clear();
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
                    Thread.Sleep(25);
                }
                Thread.Sleep(1500);
                Console.Clear();
            }*/
            MenuController.Start();
        }
    }
}
