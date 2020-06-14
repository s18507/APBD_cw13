using APBD_cw13.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Models
{
    public class SweetStoreDbContext : DbContext
    {
        public SweetStoreDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        public SweetStoreDbContext()
        {

        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Employee_confectionary> Employeess { get; set; }
        public DbSet<Customer_confectionary> Customers { get; set; }
        public DbSet<Confectionary> Confectionaries { get; set; }
        public DbSet<Confectionary_Order> confectionary_Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new Confectionary_OrderConfig());
            modelBuilder.ApplyConfiguration(new ConfectionaryConfig());

            //Seed Data
            modelBuilder.Seed();
        }
    }
}
