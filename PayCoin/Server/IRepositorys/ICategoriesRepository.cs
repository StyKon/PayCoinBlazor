using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.IRepositorys
{
    public interface ICategoriesRepository
    {   Task<ActionResult<IEnumerable<Category>>> GetCategory();
        Task<ActionResult<Category>> GetCategory(long id);
        Task<ActionResult<Category>> PutCategory(long id, Category category);
        Task<ActionResult<Category>> PostCategory(Category category);
        Task<ActionResult<Category>> DeleteCategory(long id);
        bool CategoryExists(long id);
     
    }
}
