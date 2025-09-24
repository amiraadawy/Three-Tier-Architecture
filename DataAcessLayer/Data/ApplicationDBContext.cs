using DataAcessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial customers
            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer { Id = 1, Name = "John Doe", Email = "john@example.com", Phone = "1234567890", Address = "123 Main St" },
            //    new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Phone = "9876543210", Address = "456 Park Ave" },
            //    new Customer { Id = 3, Name = "Ali Hassan", Email = "ali@example.com", Phone = "01011223344", Address = "Cairo, Egypt" }
            //);
        }
    }
}
