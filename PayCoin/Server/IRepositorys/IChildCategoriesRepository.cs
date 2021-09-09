using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.IRepositorys
{
    public interface IChildCategoriesRepository
    {
        Task<ActionResult<IEnumerable<ChildCategory>>> GetChildCategory();
        Task<ActionResult<IEnumerable<ChildCategory>>> GetByCategory(long id);
        Task<ActionResult<ChildCategory>> GetChildCategory(long id);
        Task<ActionResult<ChildCategory>> PutChildCategory(long id, ChildCategory childCategory);
        Task<ActionResult<ChildCategory>> PostChildCategory(ChildCategory childCategory);
        Task<ActionResult<ChildCategory>> DeleteChildCategory(long id);
        bool ChildCategoryExists(long id);
    }
}
