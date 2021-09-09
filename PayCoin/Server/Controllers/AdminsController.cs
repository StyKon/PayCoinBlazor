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
    public class AdminsController : ControllerBase
    {
        private readonly IAdminsRepository _repository;

        public AdminsController(IAdminsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmin()
        {
            return await _repository.GetAdmin();
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(long id)
        {
            return await _repository.GetAdmin(id);
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Admin>> PutAdmin(long id, Admin admin)
        {
            return await _repository.PutAdmin(id, admin);
        }

        // POST: api/Admins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            return await _repository.PostAdmin(admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> DeleteAdmin(long id)
        {
            return await _repository.DeleteAdmin(id);
        }
    }
}
