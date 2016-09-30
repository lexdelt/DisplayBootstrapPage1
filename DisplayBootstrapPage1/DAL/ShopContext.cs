using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DisplayBootstrapPage1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DisplayBootstrapPage1.DAL
{
    public class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext() : base("ShopContext")
        {
        }
        public static ShopContext Create()
        {
            return new ShopContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}