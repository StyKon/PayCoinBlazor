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
    public class ChildCategoriesController : ControllerBase
    {
        private readonly IChildCategoriesRepository _repository;

        public ChildCategoriesController(IChildCategoriesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ChildCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChildCategory>>> GetChildCategory()
        {
            return await _repository.GetChildCategory();
        }

        // GET: api/ChildCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChildCategory>> GetChildCategory(long id)
        {
            return await _repository.GetChildCategory(id);
        }
        // GET: api/ChildCategories/GetbyCategory/5
        [HttpGet("GetByCategory/{id}")]
        public async Task<ActionResult<IEnumerable<ChildCategory>>> GetByCategory(long id)
        {
            return await _repository.GetByCategory(id);
        }
        // PUT: api/ChildCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ChildCategory>> PutChildCategory(long id, ChildCategory childCategory)
        {
            return await _repository.PutChildCategory(id, childCategory);
        }

        // POST: api/ChildCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChildCategory>> PostChildCategory(ChildCategory childCategory)
        {
            return await _repository.PostChildCategory(childCategory);
        }

        // DELETE: api/ChildCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChildCategory>> DeleteChildCategory(long id)
        {
            return await _repository.DeleteChildCategory(id);
        }
    }
}
