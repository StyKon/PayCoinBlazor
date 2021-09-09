using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.IRepositorys
{
    public interface ISmallCategoriesRepository
    {
        Task<ActionResult<IEnumerable<SmallCategory>>> GetSmallCategory();
        Task<ActionResult<IEnumerable<SmallCategory>>> GetByChildCategory(long id);
        Task<ActionResult<SmallCategory>> GetSmallCategory(long id);
        Task<ActionResult<SmallCategory>> PutSmallCategory(long id, SmallCategory smallCategory);
        Task<ActionResult<SmallCategory>> PostSmallCategory(SmallCategory smallCategory);
        Task<ActionResult<SmallCategory>> DeleteSmallCategory(long id);
        bool SmallCategoryExists(long id);
    }
}
