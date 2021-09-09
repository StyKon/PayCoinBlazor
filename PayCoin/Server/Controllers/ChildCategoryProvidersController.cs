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
    public class ChildCategoryProvidersController : ControllerBase
    {
        private readonly IChildCategoryProvidersRepository _repository;

        public ChildCategoryProvidersController(IChildCategoryProvidersRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ChildCategoryProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChildCategoryProvider>>> GetChildCategoryProvider()
        {
            return await _repository.GetChildCategoryProvider();
        }

        // GET: api/ChildCategoryProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChildCategoryProvider>> GetChildCategoryProvider(long id)
        {
            return await _repository.GetChildCategoryProvider(id);
        }

        // PUT: api/ChildCategoryProviders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<ChildCategoryProvider>> PutChildCategoryProvider(long id, ChildCategoryProvider childCategoryProvider)
        {
            return await _repository.PutChildCategoryProvider(id, childCategoryProvider);
        }

        // POST: api/ChildCategoryProviders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChildCategoryProvider>> PostChildCategoryProvider(ChildCategoryProvider childCategoryProvider)
        {
            return await _repository.PostChildCategoryProvider(childCategoryProvider);
        }

        // DELETE: api/ChildCategoryProviders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChildCategoryProvider>> DeleteChildCategoryProvider(long id)
        {
            return await _repository.DeleteChildCategoryProvider(id);
        }
    }
}
