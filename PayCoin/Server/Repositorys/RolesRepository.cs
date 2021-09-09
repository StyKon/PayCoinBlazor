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
    public class RolesRepository : IRolesRepository
    {
        private readonly PayCoinContext _context;
        public RolesRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<Role>>> GetRole()
        {
            return await _context.Role.ToListAsync();
        }
        public async Task<ActionResult<Role>> GetRole(long id)
        {
            var role = await _context.Role.FindAsync(id);

            if (role == null)
            {
                return role;
            }

            return role;
        }
        public async Task<ActionResult<Role>> PutRole(long id, Role role)
        {
            if (id != role.RoleId)
            {
                return role;
            }

            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
                {
                    return role;
                }
                else
                {
                    throw;
                }
            }

            return role;
        }
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            _context.Role.Add(role);
            await _context.SaveChangesAsync();

            return role;
        }
        public async Task<ActionResult<Role>> DeleteRole(long id)
        {
            var role = await _context.Role.FindAsync(id);
            if (role == null)
            {
                return role;
            }

            _context.Role.Remove(role);
            await _context.SaveChangesAsync();

            return role;
        }

        public bool RoleExists(long id)
        {
            return _context.Role.Any(e => e.RoleId == id);
        }

    }
}
