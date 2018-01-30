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
        }
    }
}