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
    public class SmallCategoriesController : ControllerBase
    {
        private readonly ISmallCategoriesRepository _repository;

        public SmallCategoriesController(ISmallCategoriesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/SmallCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmallCategory>>> GetSmallCategory()
        {
            return await _repository.GetSmallCategory();
        }

        // GET: api/SmallCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SmallCategory>> GetSmallCategory(long id)
        {
            return await _repository.GetSmallCategory(id);
        }
        // GET: api/ChildCategories/GetByChildCategory/5
        [HttpGet("GetByChildCategory/{id}")]
        public async Task<ActionResult<IEnumerable<SmallCategory>>> GetByChildCategory(long id)
        {
            return await _repository.GetByChildCategory(id);
        }

        // PUT: api/SmallCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<SmallCategory>> PutSmallCategory(long id, SmallCategory smallCategory)
        {
            return await _repository.PutSmallCategory(id, smallCategory);
        }

        // POST: api/SmallCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SmallCategory>> PostSmallCategory(SmallCategory smallCategory)
        {
            return await _repository.PostSmallCategory(smallCategory);
        }

        // DELETE: api/SmallCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SmallCategory>> DeleteSmallCategory(long id)
        {
            return await _repository.DeleteSmallCategory(id);
        }
    }
}
