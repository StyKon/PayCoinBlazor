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
    public class CommunitiesRepository : ICommunitiesRepository
    {
        private readonly PayCoinContext _context;
        public CommunitiesRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<Community>>> GetCommunity()
        {
            return await _context.Community.ToListAsync();
        }
        public async Task<ActionResult<Community>> GetCommunity(long id)
        {
            var community = await _context.Community.FindAsync(id);

            if (community == null)
            {
                return community;
            }

            return community;
        }
        public async Task<ActionResult<Community>> PutCommunity(long id, Community community)
        {
            if (id != community.CommunityId)
            {
                return community;
            }

            _context.Entry(community).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityExists(id))
                {
                    return community;
                }
                else
                {
                    throw;
                }
            }

            return community;
        }
        public async Task<ActionResult<Community>> PostCommunity(Community community)
        {
            _context.Community.Add(community);
            await _context.SaveChangesAsync();

            return community;
        }
        public async Task<ActionResult<Community>> DeleteCommunity(long id)
        {
            var community = await _context.Community.FindAsync(id);
            if (community == null)
            {
                return community;
            }

            _context.Community.Remove(community);
            await _context.SaveChangesAsync();

            return community;
        }

        public bool CommunityExists(long id)
        {
            return _context.Community.Any(e => e.CommunityId == id);
        }
    }
}
