using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSales.Domain;

namespace OnlineSales.Infrastructure
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí puedes configurar restricciones adicionales, índices, relaciones, etc.
            base.OnModelCreating(modelBuilder);
        }
    }
}
