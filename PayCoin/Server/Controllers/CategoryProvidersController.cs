using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayCoin.Server.Data;
using PayCoin.Server.IRepositorys;
using PayCoin.Server.Models;

namespace PayCoin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryProvidersController : ControllerBase
    {
        private readonly ICategoryProvidersRepository _repository;

        public CategoryProvidersController(ICategoryProvidersRepository repository)
        {
            _repository = repository;
        }

        // GET: api/CategoryProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryProvider>>> GetCategoryProvider()
        {
            return await _repository.GetCategoryProvider();
        }

        // GET: api/CategoryProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryProvider>> GetCategoryProvider(long id)
        {
            return await _repository.GetCategoryProvider(id);
        }

        // PUT: api/CategoryProviders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryProvider>> PutCategoryProvider(long id, CategoryProvider categoryProvider)
        {
            return await _repository.PutCategoryProvider(id, categoryProvider);
        }

        // POST: api/CategoryProviders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategoryProvider>> PostCategoryProvider(CategoryProvider categoryProvider)
        {
            return await _repository.PostCategoryProvider(categoryProvider);
        }

        // DELETE: api/CategoryProviders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryProvider>> DeleteCategoryProvider(long id)
        {
            return await _repository.DeleteCategoryProvider(id);
        }
    }
}
