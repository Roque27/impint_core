using System;
using System.Collections.Generic;
using System.Text;

namespace Launcher
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            //services.AddSingleton<IMyService, MyService>();
        }
    }

    public interface IMyService
    {
        Task MyServiceMethod();
    }
}
 