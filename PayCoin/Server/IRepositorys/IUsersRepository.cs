using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.IRepositorys
{
    public interface IUsersRepository
    {
        Task<ActionResult<IEnumerable<User>>> GetUser();
        Task<ActionResult<User>> GetUser(long id);
        Task<ActionResult<User>> PutUser(long id, UserRoleModel userRoleModel);
        Task<ActionResult<User>> PostUser(UserRoleModel userRoleModel);
        Task<ActionResult<User>> DeleteUser(long id);
        bool UserExists(long id);
    }
}
