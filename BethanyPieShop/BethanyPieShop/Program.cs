using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BethanyPieShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Sets up application with some defaults
            Host is being setup which configures a server and a request processing pipeline. */
            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    DbInitializer.Seed(context);
                }
                catch (Exception)
                {
                    //We could log this in a real-world situation
                }
 
            }

            host.Run();
        }

        /* This sets up some application defaults and in this process, 
         * configures a web server called Kestrel as the default web server technology. */
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)  //Sets up environment and uses many defaults
                .UseStartup<Startup>();
     }
}
