using System;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BethanyPieShop.Areas.Identity.IdentityHostingStartup))]
namespace BethanyPieShop.Areas.Identity
{
    //Class used to configure Identity
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //Bring in support for Identity in the services collection
                services.AddDefaultIdentity<IdentityUser>()
                //AppDbCOntext will be used to store my Identity Information (User information and so on)
                .AddEntityFrameworkStores<AppDbContext>();
            });
        }
    }
}