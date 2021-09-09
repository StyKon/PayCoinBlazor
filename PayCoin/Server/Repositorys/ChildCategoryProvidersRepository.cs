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
    public class ChildCategoryProvidersRepository : IChildCategoryProvidersRepository
    {
        private readonly PayCoinContext _context;
        public ChildCategoryProvidersRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<ChildCategoryProvider>>> GetChildCategoryProvider()
        {
            return await _context.ChildCategoryProvider.ToListAsync();
        }
        public async Task<ActionResult<ChildCategoryProvider>> GetChildCategoryProvider(long id)
        {
            var childCategoryProvider = await _context.ChildCategoryProvider.FindAsync(id);

            if (childCategoryProvider == null)
            {
                return childCategoryProvider;
            }

            return childCategoryProvider;
        }
        public async Task<ActionResult<ChildCategoryProvider>> PutChildCategoryProvider(long id, ChildCategoryProvider childCategoryProvider)
        {
            if (id != childCategoryProvider.ChildCategoryProviderId)
            {
                return childCategoryProvider;
            }

            _context.Entry(childCategoryProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildCategoryProviderExists(id))
                {
                    return childCategoryProvider;
                }
                else
                {
                    throw;
                }
            }

            return childCategoryProvider;
        }
        public async Task<ActionResult<ChildCategoryProvider>> PostChildCategoryProvider(ChildCategoryProvider childCategoryProvider)
        {
            _context.ChildCategoryProvider.Add(childCategoryProvider);
            await _context.SaveChangesAsync();

            return childCategoryProvider;
        }
        public async Task<ActionResult<ChildCategoryProvider>> DeleteChildCategoryProvider(long id)
        {
            var childCategoryProvider = await _context.ChildCategoryProvider.FindAsync(id);
            if (childCategoryProvider == null)
            {
                return childCategoryProvider;
            }

            _context.ChildCategoryProvider.Remove(childCategoryProvider);
            await _context.SaveChangesAsync();

            return childCategoryProvider;
        }

        public bool ChildCategoryProviderExists(long id)
        {
            return _context.ChildCategoryProvider.Any(e => e.ChildCategoryProviderId == id);
        }
    }
}
