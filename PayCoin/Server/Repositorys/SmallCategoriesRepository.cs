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
    public class SmallCategoriesRepository : ISmallCategoriesRepository
    {
        private readonly PayCoinContext _context;
        public SmallCategoriesRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<SmallCategory>>> GetSmallCategory()
        {
            return await _context.SmallCategory.ToListAsync();
        }
        public async Task<ActionResult<SmallCategory>> GetSmallCategory(long id)
        {
            var smallCategory = await _context.SmallCategory.FindAsync(id);

            if (smallCategory == null)
            {
                return smallCategory;
            }

            return smallCategory;
        }
        public async Task<ActionResult<IEnumerable<SmallCategory>>> GetByChildCategory(long id)
        {
            var smallCategory = await _context.SmallCategory.Where(a => a.ChildCategoryId == id).ToListAsync();

            if (smallCategory == null)
            {
                return smallCategory;
            }

            return smallCategory;
        }
        public async Task<ActionResult<SmallCategory>> PutSmallCategory(long id, SmallCategory smallCategory)
        {
            if (id != smallCategory.SmallCategoryId)
            {
                return smallCategory;
            }
            smallCategory.Slug = await _context.SmallCategory
              .Where(x => x.SmallCategoryId == id)
           .Select(u => u.Slug)
          .FirstOrDefaultAsync();
            _context.Entry(smallCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmallCategoryExists(id))
                {
                    return smallCategory;
                }
                else
                {
                    throw;
                }
            }

            return smallCategory;
        }
        public async Task<ActionResult<SmallCategory>> PostSmallCategory(SmallCategory smallCategory)
        {
            var smallcategorys = _context.SmallCategory.Select(x => new SmallCategory
            {
                Slug = x.Slug
            })
            .ToList();
            smallCategory.Slug = smallCategory.Title.GenerateUniqueSlug(smallcategorys);
            _context.SmallCategory.Add(smallCategory);
            await _context.SaveChangesAsync();

            return smallCategory;
        }
        public async Task<ActionResult<SmallCategory>> DeleteSmallCategory(long id)
        {
            var smallCategory = await _context.SmallCategory.FindAsync(id);
            if (smallCategory == null)
            {
                return smallCategory;
            }

            _context.SmallCategory.Remove(smallCategory);
            await _context.SaveChangesAsync();

            return smallCategory;
        }

        public bool SmallCategoryExists(long id)
        {
            return _context.SmallCategory.Any(e => e.SmallCategoryId == id);
        }
    }
}
