using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayCoin.Server.Data;
using PayCoin.Server.IRepositorys;
using PayCoin.Server.Models;
using SlugGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Repositorys
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly PayCoinContext _context;
        public ProductsRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return product;
            }

            return product;
        }
        public async Task<ActionResult<Product>> PutProduct(long id, Product product)
        {
            if (id != product.ProductId)
            {
                return product;
            }
            product.Slug = await _context.Product
              .Where(x => x.ProductId == id)
              .Select(u => u.Slug)
              .FirstOrDefaultAsync();
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return product;
                }
                else
                {
                    throw;
                }
            }

            return product;
        }
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var products = _context.Product.Select(x => new Product
            {
                Slug = x.Slug
            })
           .ToList();
            product.Slug = product.Title.GenerateUniqueSlug(products);
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return product;
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetActiveProductForProvider(long providerid)
        {
            var providerproducts = await _context.Product.Where(a => a.ProviderId == providerid).Where(a => a.Status == "active").ToListAsync();

            if (providerproducts == null)
            {
                return providerproducts;
            }

            return providerproducts;
        }
    }
}
