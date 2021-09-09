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
    public class ProvidersRepository : IProvidersRepository
    {
        private readonly PayCoinContext _context;
        public ProvidersRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<Provider>>> GetProvider()
        {
            return await _context.Provider.ToListAsync();
        }
        public async Task<ActionResult<Provider>> GetProvider(long id)
        {
            var provider = await _context.Provider.FindAsync(id);

            if (provider == null)
            {
                return provider;
            }

            return provider;
        }
        public async Task<ActionResult<Provider>> PutProvider(long id, Provider provider)
        {
            if (id != provider.ProviderId)
            {
                return provider;
            }

            _context.Entry(provider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(id))
                {
                    return provider;
                }
                else
                {
                    throw;
                }
            }

            return provider;
        }
        public async Task<ActionResult<Provider>> PostProvider(Provider provider)
        {
            _context.Provider.Add(provider);
            await _context.SaveChangesAsync();

            return provider;
        }
        public async Task<ActionResult<Provider>> DeleteProvider(long id)
        {
            var provider = await _context.Provider.FindAsync(id);
            if (provider == null)
            {
                return provider;
            }

            _context.Provider.Remove(provider);
            await _context.SaveChangesAsync();

            return provider;
        }

        public bool ProviderExists(long id)
        {
            return _context.Provider.Any(e => e.ProviderId == id);
        }
    }
}
