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
    public class DeliveriesRepository : IDeliveriesRepository
    {
        private readonly PayCoinContext _context;
        public DeliveriesRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDelivery()
        {
            return await _context.Delivery.ToListAsync();
        }
        public async Task<ActionResult<Delivery>> GetDelivery(long id)
        {
            var delivery = await _context.Delivery.FindAsync(id);

            if (delivery == null)
            {
                return delivery;
            }

            return delivery;
        }
        public async Task<ActionResult<Delivery>> PutDelivery(long id, Delivery delivery)
        {
            if (id != delivery.DeliveryId)
            {
                return delivery;
            }

            _context.Entry(delivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(id))
                {
                    return delivery;
                }
                else
                {
                    throw;
                }
            }

            return delivery;
        }
        public async Task<ActionResult<Delivery>> PostDelivery(Delivery delivery)
        {
            _context.Delivery.Add(delivery);
            await _context.SaveChangesAsync();

            return delivery;
        }
        public async Task<ActionResult<Delivery>> DeleteDelivery(long id)
        {
            var delivery = await _context.Delivery.FindAsync(id);
            if (delivery == null)
            {
                return delivery;
            }

            _context.Delivery.Remove(delivery);
            await _context.SaveChangesAsync();

            return delivery;
        }

        public bool DeliveryExists(long id)
        {
            return _context.Delivery.Any(e => e.DeliveryId == id);
        }
    }
}
