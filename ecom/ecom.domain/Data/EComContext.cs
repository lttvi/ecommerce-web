using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ecom.domain.Models;

namespace ecom.domain.Data
{
    public class EComContext : DbContext
    {

        public EComContext(DbContextOptions<EComContext> options)
        : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=VIVOBOOK-S15\\SQLEXPRESS;Initial Catalog=ecom;Integrated Security=True;");
        }

    }


    /*
    private readonly string _connectionString;

    public EComContext(string connectionString)
    {
        _connectionString = connectionString;
    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    */

}


