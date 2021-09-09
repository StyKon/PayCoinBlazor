using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayCoin.Server.Data;
using PayCoin.Server.IRepositorys;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Repositorys
{
    public class CategoryProvidersRepository : ICategoryProvidersRepository
    {
        private readonly PayCoinContext _context;
        public CategoryProvidersRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<CategoryProvider>>> GetCategoryProvider()
        {
            return await _context.CategoryProvider.ToListAsync();
        }
        public async Task<ActionResult<CategoryProvider>> GetCategoryProvider(long id)
        {
            var categoryProvider = await _context.CategoryProvider.FindAsync(id);

            if (categoryProvider == null)
            {
                return categoryProvider;
            }

            return categoryProvider;
        }
        public async Task<ActionResult<CategoryProvider>> PutCategoryProvider(long id, CategoryProvider categoryProvider)
        {
            if (id != categoryProvider.CategoryProviderId)
            {
                return categoryProvider;
            }

            _context.Entry(categoryProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryProviderExists(id))
                {
                    return categoryProvider;
                }
                else
                {
                    throw;
                }
            }

            return categoryProvider;
        }
        public async Task<ActionResult<CategoryProvider>> PostCategoryProvider(CategoryProvider categoryProvider)
        {
            _context.CategoryProvider.Add(categoryProvider);
            await _context.SaveChangesAsync();

            return categoryProvider;
        }
        public async Task<ActionResult<CategoryProvider>> DeleteCategoryProvider(long id)
        {
            var categoryProvider = await _context.CategoryProvider.FindAsync(id);
            if (categoryProvider == null)
            {
                return categoryProvider;
            }

            _context.CategoryProvider.Remove(categoryProvider);
            await _context.SaveChangesAsync();

            return categoryProvider;
        }

        public bool CategoryProviderExists(long id)
        {
            return _context.CategoryProvider.Any(e => e.CategoryProviderId == id);
        }
    }
}
