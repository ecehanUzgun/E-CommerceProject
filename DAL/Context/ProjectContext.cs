using DAL.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class ProjectContext:IdentityDbContext<User,IdentityRole<int>,int>
    {

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        public ProjectContext()
        {

        }



        //DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }




        //Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //UseSqlserver

            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer("server=KDK-404-PC11-YZ;database=EcommerceDB;uid=sa;pwd=123;TrustServerCertificate=True;");


            base.OnConfiguring(optionsBuilder);
        }

        //ModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //todo: İlgili entityler içerisinde özelleştirilmesi gereken özellikler burada tanımlancak.


            //Category Configuration
            builder.ApplyConfiguration(new CategoryConfiguration());

            //Product Configuration
            builder.ApplyConfiguration(new ProductConfiguration());

            //Order Configuration
            builder.ApplyConfiguration(new OrderConfiguration());

            //OrderDetail Configuration
            builder.ApplyConfiguration(new OrderDetailConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
