using System.Collections.Generic;
using System.Threading.Tasks;
using PayCoin.Client.Models;

namespace PayCoin.Client.Services
{
    public interface IProviderService
    {
         Task<IEnumerable<Provider>> GetAllProviders();
         Task<Provider> GetProvider(int id);
         Task<Provider> AddProvider(Provider provider);
         Task UpdateProvider(Provider provider);
         Task DeleteProvider(int id);
    }
}