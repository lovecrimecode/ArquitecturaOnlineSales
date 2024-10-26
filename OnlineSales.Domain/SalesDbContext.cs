using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using OnlineSales.Domain;

public class SalesDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            object _context = optionsBuilder.UseSqlite("Data Source=online_sales.db");
        }
    }
}
