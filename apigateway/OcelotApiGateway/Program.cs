using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;

namespace OcelotApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHostBuilder builder = new WebHostBuilder();
            builder.ConfigureServices(s =>
            {
                s.AddSingleton(builder);
            });
            builder.UseKestrel()
                   .UseContentRoot(Directory.GetCurrentDirectory())
                   .UseStartup<Startup>()
                   .UseUrls("http://localhost:9000");

            var host = builder.Build();
            host.Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            IWebHostBuilder builder = WebHost.CreateDefaultBuilder(args);

            //WebHost.CreateDefaultBuilder(args)
            //    .UseStartup<Startup>();

            builder.ConfigureServices(s => s.AddSingleton(builder))
               .ConfigureAppConfiguration(ic => ic.AddJsonFile("configuration.json"))
               .UseStartup<Startup>();

            IWebHost host = builder.Build();
            return host;
        }
    }
}
