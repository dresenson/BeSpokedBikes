using BeSpokedBikes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.Repository
{
    public class BikesDBContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Salesperson> Salespersons { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public BikesDBContext(DbContextOptions<BikesDBContext> options) : base(options) { }
    }
}
