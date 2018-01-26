using Core;
using System;

namespace Launcher
{
    class Impint
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            // Startup.cs finally :)
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogDebug("Logger is working!");

            // Get Service and call method
            var service = serviceProvider.GetService<IMyService>();
            service.MyServiceMethod();


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