using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayCoin.Server.Models;

namespace PayCoin.Server.IRepositorys
{
    public interface IRolesRepository
    {
        Task<ActionResult<IEnumerable<Role>>> GetRole();
        Task<ActionResult<Role>> GetRole(long id);
        Task<ActionResult<Role>> PutRole(long id, Role role);
        Task<ActionResult<Role>> PostRole(Role role);
        Task<ActionResult<Role>> DeleteRole(long id);
        bool RoleExists(long id);
    }
}
