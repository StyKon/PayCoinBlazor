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
    public class ShippingsRepository : IShippingsRepository
    {
        private readonly PayCoinContext _context;
        public ShippingsRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<Shipping>>> GetShipping()
        {
            return await _context.Shipping.ToListAsync();
        }
        public async Task<ActionResult<Shipping>> GetShipping(long id)
        {
            var shipping = await _context.Shipping.FindAsync(id);

            if (shipping == null)
            {
                return shipping;
            }

            return shipping;
        }
        public async Task<ActionResult<Shipping>> PutShipping(long id, Shipping shipping)
        {
            if (id != shipping.ShippingId)
            {
                return shipping;
            }

            _context.Entry(shipping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingExists(id))
                {
                    return shipping;
                }
                else
                {
                    throw;
                }
            }

            return shipping;
        }
        public async Task<ActionResult<Shipping>> PostShipping(Shipping shipping)
        {
            _context.Shipping.Add(shipping);
            await _context.SaveChangesAsync();

            return shipping;
        }
        public async Task<ActionResult<Shipping>> DeleteShipping(long id)
        {
            var shipping = await _context.Shipping.FindAsync(id);
            if (shipping == null)
            {
                return shipping;
            }

            _context.Shipping.Remove(shipping);
            await _context.SaveChangesAsync();

            return shipping;
        }

        public bool ShippingExists(long id)
        {
            return _context.Shipping.Any(e => e.ShippingId == id);
        }

    }
}
