using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineSales.Domain;
using OnlineSales.Infrastructure;

namespace OnlineSales.Application
{
    public class ProductService
    {
        private readonly SalesDbContext _context;

        public ProductService(SalesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync() => await _context.Products.ToListAsync();

        public async Task<Product> GetByIdAsync(int id) => await _context.Products.FindAsync(id);

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            if (!_context.Products.Any(p => p.Id == product.Id))
            {
                return false;
            }
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}