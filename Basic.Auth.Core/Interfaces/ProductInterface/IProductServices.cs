using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Basic.Auth.Models;

namespace Basic.Auth.Core.Interfaces.ProductInterface
{
    public interface IProductServices
    {
         Task AddAProductAsync(Product product);
         Task<Product> GetAProductAsync(int productId);
        Task DeleteAProductAsync(int productId);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task UpdateProductAsync(Product product);
    }
}
