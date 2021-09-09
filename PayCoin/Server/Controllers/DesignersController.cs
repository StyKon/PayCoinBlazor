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
    public class DesignersController : ControllerBase
    {
        private readonly IDesignersRepository _repository;

        public DesignersController(IDesignersRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Designers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Designer>>> GetDesigner()
        {
            return await _repository.GetDesigner();
        }

        // GET: api/Designers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Designer>> GetDesigner(long id)
        {
            return await _repository.GetDesigner(id);
        }

        // PUT: api/Designers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Designer>> PutDesigner(long id, Designer designer)
        {
            return await _repository.PutDesigner(id, designer);
        }

        // POST: api/Designers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Designer>> PostDesigner(Designer designer)
        {
            return await _repository.PostDesigner(designer);
        }

        // DELETE: api/Designers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Designer>> DeleteDesigner(long id)
        {
            return await _repository.DeleteDesigner(id);
        }
    }
}
