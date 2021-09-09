using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayCoin.Server.Data;
using PayCoin.Server.IRepositorys;
using PayCoin.Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunitiesController : ControllerBase
    {
        private readonly ICommunitiesRepository _repository;

        public CommunitiesController(ICommunitiesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Communities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Community>>> GetCommunity()
        {
            return await _repository.GetCommunity();
        }

        // GET: api/Communities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Community>> GetCommunity(long id)
        {
            return await _repository.GetCommunity(id);
        }

        // PUT: api/Communities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Community>> PutCommunity(long id, Community community)
        {
            return await _repository.PutCommunity(id, community);
        }

        // POST: api/Communities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Community>> PostCommunity(Community community)
        {
            return await _repository.PostCommunity(community);
        }

        // DELETE: api/Communities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Community>> DeleteCommunity(long id)
        {
            return await _repository.DeleteCommunity(id);
        }
    }
}
