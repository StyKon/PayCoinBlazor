using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayCoin.Server.Data;
using PayCoin.Server.IRepositorys;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SlugGenerator;

namespace PayCoin.Server.Repositorys
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly PayCoinContext _context;
        public CategoriesRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _context.Category.ToListAsync();
        }
        public async Task<ActionResult<Category>> GetCategory(long id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return category;
            }

            return category;
        }
        public async Task<ActionResult<Category>> PutCategory(long id, Category category)
        {
            if (id != category.CategoryId)
            {
                return category;
            }
            category.Slug = await _context.Category
                .Where(x => x.CategoryId == id)
  .Select(u => u.Slug)
            .FirstOrDefaultAsync();
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return category;
                }
                else
                {
                    throw;
                }
            }

            return category;
        }
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
           var categorys=  _context.Category.Select(x => new Category
           {
               Slug = x.Slug
           })
            .ToList();
            category.Slug = category.Title.GenerateUniqueSlug(categorys);
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }
        public async Task<ActionResult<Category>> DeleteCategory(long id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return category;
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public bool CategoryExists(long id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
