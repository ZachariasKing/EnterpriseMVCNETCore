using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BethanyPieShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        //The configuration class which has been injected here contains all the information read out by the Program.cs class
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the DI container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        //Registering services for the application
        public void ConfigureServices(IServiceCollection services)
        {

            //Register that we are using EF Core for databases. Use SQL server for underlying database for my appDbContext
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //We need to add MVC to the services collection so our application 'knows' about MVC
            services.AddMvc();
            /*
             * Whenever someone is asking for the IPieRepository, they recieve the PieRepository - This is handled by the 
             * built-in dependency injection in .NET Core. This occurs in the HomeController class for instance.
             */
            services.AddTransient<IPieRespository, PieRepository>();

            //Similar to above, we add feedback repository into DI container
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) 
        {
            //Middleware components that intercept/handle the HTTP requests/responses 
            app.UseDeveloperExceptionPage(); //Ensures that when something goes wrong, we get exception
            app.UseStatusCodePages(); //Show info about status of request if returned
            app.UseStaticFiles();   // support for static files - searches for files in wwwroot by default for static files
            app.UseAuthentication();    //App is now configured to use ASP identity
            //Here we make our routes so that MVC can navigate our pages
            app.UseMvc(routes =>
            {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{Action=Index}/{id?}"
                  );
            }
            );
            //app.UseMvcWithDefaultRoute(); //The above method may short circuit and actually provide a response to the client without passing the request to this method so this shoudl be last
        }
    }
}
