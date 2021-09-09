using System.Collections.Generic;
using System.Threading.Tasks;
using PayCoin.Client.Models;

namespace PayCoin.Client.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> GetAllCategorys();
         Task<Category> GetCategory(int id);
         Task<Category> AddCategory(Category category);
         Task UpdateCategory(Category category);
         Task DeleteCategory(int id);
    }
}