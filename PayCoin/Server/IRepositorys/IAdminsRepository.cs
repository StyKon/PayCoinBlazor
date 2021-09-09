using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayCoin.Server.Models;

namespace PayCoin.Server.IRepositorys
{
    public interface IAdminsRepository
    {
        Task<ActionResult<IEnumerable<Admin>>> GetAdmin();
        Task<ActionResult<Admin>> GetAdmin(long id);
        Task<ActionResult<Admin>> PutAdmin(long id, Admin admin);
        Task<ActionResult<Admin>> PostAdmin(Admin admin);
        Task<ActionResult<Admin>> DeleteAdmin(long id);
        bool AdminExists(long id);
    }
}
