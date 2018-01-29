using Core;
using System;

namespace Launcher
{
    class Impint
    {
        static void Main(string[] args)
        {
            Startup startup = new Startup();

            ControladorMaestro c = new ControladorMaestro();

            var cache = c.ObtenerCacheDeElementos();

            //DateTime fecha = DateTime.Now;
            //using (var ord = new ControladorOrdenativos())
            //{
            //    fecha = ord.Test();
            //    Console.WriteLine("La Fecha actual es: " + fecha.ToString());
            //    Console.WriteLine("");
            //    Console.WriteLine("Preciona ESC");

            //    do
            //    {
            //        while (!Console.KeyAvailable){}
            //    } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            //}
        }
    }
}