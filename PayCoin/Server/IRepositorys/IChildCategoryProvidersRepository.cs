using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.IRepositorys
{
    public interface IChildCategoryProvidersRepository
    {
        Task<ActionResult<IEnumerable<ChildCategoryProvider>>> GetChildCategoryProvider();
        Task<ActionResult<ChildCategoryProvider>> GetChildCategoryProvider(long id);
        Task<ActionResult<ChildCategoryProvider>> PutChildCategoryProvider(long id, ChildCategoryProvider childCategoryProvider);
        Task<ActionResult<ChildCategoryProvider>> PostChildCategoryProvider(ChildCategoryProvider childCategoryProvider);
        Task<ActionResult<ChildCategoryProvider>> DeleteChildCategoryProvider(long id);
        bool ChildCategoryProviderExists(long id);
    }
}
