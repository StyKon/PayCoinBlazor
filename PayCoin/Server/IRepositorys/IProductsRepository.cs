using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayCoin.Server.Models;

namespace PayCoin.Server.IRepositorys
{
    public interface IProductsRepository
    {
        Task<ActionResult<IEnumerable<Product>>> GetProduct();
        Task<ActionResult<Product>> GetProduct(long id);
        Task<ActionResult<IEnumerable<Product>>> GetActiveProductForProvider(long providerid);
        Task<ActionResult<Product>> PutProduct(long id, Product product);
        Task<ActionResult<Product>> PostProduct(Product product);
        Task<ActionResult<Product>> DeleteProduct(long id);
        bool ProductExists(long id);
    }
}
