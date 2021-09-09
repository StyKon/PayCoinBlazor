using System.Collections.Generic;
using System.Threading.Tasks;
using PayCoin.Client.Models;

namespace PayCoin.Client.Services
{
    public interface ICommunityService
    {
         Task<IEnumerable<Community>> GetAllCommunitys();
         Task<Community> GetCommunity(int id);
         Task<Community> AddCommunity(Community community);
         Task UpdateCommunity(Community community);
         Task DeleteCommunity(int id);
    }
}