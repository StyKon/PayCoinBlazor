using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.IRepositorys
{
    public interface ICommunitiesRepository
    {
        Task<ActionResult<IEnumerable<Community>>> GetCommunity();
        Task<ActionResult<Community>> GetCommunity(long id);
        Task<ActionResult<Community>> PutCommunity(long id, Community community);
        Task<ActionResult<Community>> PostCommunity(Community community);
        Task<ActionResult<Community>> DeleteCommunity(long id);
        bool CommunityExists(long id);
    }
}
