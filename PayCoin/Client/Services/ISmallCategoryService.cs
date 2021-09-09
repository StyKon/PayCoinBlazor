using System.Collections.Generic;
using System.Threading.Tasks;
using PayCoin.Client.Models;

namespace PayCoin.Client.Services
{
    public interface ISmallCategoryService
    {
         Task<IEnumerable<SmallCategory>> GetAllSmallCategorys();
        Task<IEnumerable<SmallCategory>> GetByChildCategory(int id);
        Task<SmallCategory> GetSmallCategory(int id);
         Task<SmallCategory> AddSmallCategory(SmallCategory smallCategory);
         Task UpdateSmallCategory(SmallCategory smallCategory);
         Task DeleteSmallCategory(int id);
    }
}