using System.Collections.Generic;
using System.Threading.Tasks;
using PayCoin.Client.Models;

namespace PayCoin.Client.Services
{
    public interface IChildCategoryService
    {
         Task<IEnumerable<ChildCategory>> GetAllChildCategorys();
        Task<IEnumerable<ChildCategory>> GetByCategory(int id);
        Task<ChildCategory> GetChildCategory(int id);
         Task<ChildCategory> AddChildCategory(ChildCategory childCategory);
         Task UpdateChildCategory(ChildCategory childCategory);
         Task DeleteChildCategory(int id);
    }
}