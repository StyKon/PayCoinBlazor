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
    public class ShippingsController : ControllerBase
    {
        private readonly IShippingsRepository _repository;

        public ShippingsController(IShippingsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Shippings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping>>> GetShipping()
        {
            return await _repository.GetShipping();
        }

        // GET: api/Shippings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping>> GetShipping(long id)
        {
            return await _repository.GetShipping(id);
        }

        // PUT: api/Shippings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Shipping>> PutShipping(long id, Shipping shipping)
        {
            return await _repository.PutShipping(id, shipping);

        }

        // POST: api/Shippings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shipping>> PostShipping(Shipping shipping)
        {
            return await _repository.PostShipping(shipping);
        }

        // DELETE: api/Shippings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shipping>> DeleteShipping(long id)
        {
            return await _repository.DeleteShipping(id);
        }
    }
}
