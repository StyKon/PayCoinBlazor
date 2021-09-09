using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.IRepositorys
{
    public interface ICategoryProvidersRepository
    {
        Task<ActionResult<IEnumerable<CategoryProvider>>> GetCategoryProvider();
        Task<ActionResult<CategoryProvider>> GetCategoryProvider(long id);
        Task<ActionResult<CategoryProvider>> PutCategoryProvider(long id, CategoryProvider categoryProvider);
        Task<ActionResult<CategoryProvider>> PostCategoryProvider(CategoryProvider categoryProvider);
        Task<ActionResult<CategoryProvider>> DeleteCategoryProvider(long id);
        bool CategoryProviderExists(long id);
    }
}
