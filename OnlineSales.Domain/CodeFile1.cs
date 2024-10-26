using Microsoft.EntityFrameworkCore;
using OnlineSales.Domain;

public class SalesDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=online_sales.db");
        }
    }
}
