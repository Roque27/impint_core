using System;

namespace Launcher
{
    class Impint
    {
        static void Main(string[] args)
        {
            DateTime fecha = DateTime.Now;
            Console.WriteLine("La Fecha actual es: " + fecha.ToString());
            Console.WriteLine("");
            Console.WriteLine("Preciona ESC");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}