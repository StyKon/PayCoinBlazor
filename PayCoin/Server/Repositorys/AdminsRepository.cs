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
    public class AdminsRepository : IAdminsRepository
    {
        private readonly PayCoinContext _context;
        public AdminsRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmin()
        {
            return await _context.Admin.ToListAsync();
        }
        public async Task<ActionResult<Admin>> GetAdmin(long id)
        {
            var admin = await _context.Admin.FindAsync(id);

            if (admin == null)
            {
                return admin;
            }

            return admin;
        }
        public async Task<ActionResult<Admin>> PutAdmin(long id, Admin admin)
        {
            if (id != admin.AdminId)
            {
                return admin;
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
                {
                    return admin;
                }
                else
                {
                    throw;
                }
            }

            return admin;
        }
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();

            return admin;
        }
        public async Task<ActionResult<Admin>> DeleteAdmin(long id)
        {
            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
            {
                return admin;
            }

            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();

            return admin;
        }

        public bool AdminExists(long id)
        {
            return _context.Admin.Any(e => e.AdminId == id);
        }

    }
}
