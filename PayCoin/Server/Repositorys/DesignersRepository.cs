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
    public class DesignersRepository : IDesignersRepository
    {
        private readonly PayCoinContext _context;
        public DesignersRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<Designer>>> GetDesigner()
        {
            return await _context.Designer.ToListAsync();
        }
        public async Task<ActionResult<Designer>> GetDesigner(long id)
        {
            var designer = await _context.Designer.FindAsync(id);

            if (designer == null)
            {
                return designer;
            }

            return designer;
        }
        public async Task<ActionResult<Designer>> PutDesigner(long id, Designer designer)
        {
            if (id != designer.DesignerId)
            {
                return designer;
            }

            _context.Entry(designer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignerExists(id))
                {
                    return designer;
                }
                else
                {
                    throw;
                }
            }

            return designer;
        }
        public async Task<ActionResult<Designer>> PostDesigner(Designer designer)
        {
            _context.Designer.Add(designer);
            await _context.SaveChangesAsync();

            return designer;
        }
        public async Task<ActionResult<Designer>> DeleteDesigner(long id)
        {
            var designer = await _context.Designer.FindAsync(id);
            if (designer == null)
            {
                return designer;
            }

            _context.Designer.Remove(designer);
            await _context.SaveChangesAsync();

            return designer;
        }

        public bool DesignerExists(long id)
        {
            return _context.Designer.Any(e => e.DesignerId == id);
        }
    }
}
