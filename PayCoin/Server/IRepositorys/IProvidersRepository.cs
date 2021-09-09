using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.IRepositorys
{
    public interface IProvidersRepository
    {
        Task<ActionResult<IEnumerable<Provider>>> GetProvider();
        Task<ActionResult<Provider>> GetProvider(long id);
        Task<ActionResult<Provider>> PutProvider(long id, Provider provider);
        Task<ActionResult<Provider>> PostProvider(Provider provider);
        Task<ActionResult<Provider>> DeleteProvider(long id);
        bool ProviderExists(long id);
    }
}
