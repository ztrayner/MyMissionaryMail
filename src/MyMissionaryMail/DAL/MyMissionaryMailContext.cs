using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using MyMissionaryMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMissionaryMail.DAL
{
    public class MyMissionaryMailContext : IdentityDbContext<ApplicationUser>
    {
        public MyMissionaryMailContext()
        {
        }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Missionary> Missionaries { get; set; }
        public DbSet<Mission> Missions { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
