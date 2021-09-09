using System.Collections.Generic;
using System.Threading.Tasks;
using PayCoin.Client.Models;

namespace PayCoin.Client.Services
{
    public interface IProductService
    {
         Task<IEnumerable<Product>> GetAllProducts();
         Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetActiveProductForProvider(long providerid);
        Task<Product> AddProduct(Product product);
         Task UpdateProduct(Product product);
         Task DeleteProduct(int id);
    }
}