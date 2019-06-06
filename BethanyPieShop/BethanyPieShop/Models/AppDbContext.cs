using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    //Through appDbContext, we will be able to work with different types such as User which get added
    //by the IdentityDbContext. IdentityUser represents our default user. 
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        //Below are the relations we want EF Core to manage with migrations
        public DbSet<Pie> Pies { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
