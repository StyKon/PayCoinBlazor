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
    public class ChildCategoriesRepository : IChildCategoriesRepository
    {
        private readonly PayCoinContext _context;
        public ChildCategoriesRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<ChildCategory>>> GetChildCategory()
        {
            return await _context.ChildCategory.ToListAsync();
        }
        public async Task<ActionResult<ChildCategory>> GetChildCategory(long id)
        {
            var childCategory = await _context.ChildCategory.FindAsync(id);

            if (childCategory == null)
            {
                return childCategory;
            }

            return childCategory;
        }
        public async Task<ActionResult<IEnumerable<ChildCategory>>> GetByCategory(long id)
        {
            var childCategory = await _context.ChildCategory.Where(a => a.CategoryId == id).ToListAsync();

            if (childCategory == null)
            {
                return childCategory;
            }

            return childCategory;
        }
        public async Task<ActionResult<ChildCategory>> PutChildCategory(long id, ChildCategory childCategory)
        {
            if (id != childCategory.ChildCategoryId)
            {
                return childCategory;
            }
            childCategory.Slug = await _context.ChildCategory
               .Where(x => x.ChildCategoryId == id)
            .Select(u => u.Slug)
           .FirstOrDefaultAsync();
            _context.Entry(childCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildCategoryExists(id))
                {
                    return childCategory;
                }
                else
                {
                    throw;
                }
            }

            return childCategory;
        }
        public async Task<ActionResult<ChildCategory>> PostChildCategory(ChildCategory childCategory)
        {
            var childcategorys = _context.ChildCategory.Select(x => new ChildCategory
            {
                Slug = x.Slug
            })
            .ToList();
            childCategory.Slug = childCategory.Title.GenerateUniqueSlug(childcategorys);
            _context.ChildCategory.Add(childCategory);
            await _context.SaveChangesAsync();

            return childCategory;
        }
        public async Task<ActionResult<ChildCategory>> DeleteChildCategory(long id)
        {
            var childCategory = await _context.ChildCategory.FindAsync(id);
            if (childCategory == null)
            {
                return childCategory;
            }

            _context.ChildCategory.Remove(childCategory);
            await _context.SaveChangesAsync();

            return childCategory;
        }

        public bool ChildCategoryExists(long id)
        {
            return _context.ChildCategory.Any(e => e.ChildCategoryId == id);
        }
    }
}
