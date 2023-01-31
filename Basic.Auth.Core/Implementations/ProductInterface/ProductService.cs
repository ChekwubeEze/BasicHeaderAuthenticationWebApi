using Basic.Auth.Core.Interfaces.ProductInterface;
using Basic.Auth.Infrastructure;
using Basic.Auth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Auth.Core.Implementations.ProductInterface
{
    public class ProductService : IProductServices
    {
        private readonly BasicAuthDBContext _context;

        public ProductService(BasicAuthDBContext context)
        {
            _context = context;
        }
        public async Task AddAProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
             _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetAProductAsync(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products =  _context.Products;
            return await products.ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
             _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
