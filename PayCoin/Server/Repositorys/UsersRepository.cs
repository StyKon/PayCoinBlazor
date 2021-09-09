using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayCoin.Server.Data;
using PayCoin.Server.IRepositorys;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Repositorys
{
    public class UsersRepository : IUsersRepository
    {
        private readonly PayCoinContext _context;
        public UsersRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return user;
            }

            return user;
        }
        public async Task<ActionResult<User>> PutUser(long id, UserRoleModel userRoleModel)
        {
            if (id != userRoleModel.user.UserId)
            {
                return userRoleModel.user;
            }
            var user = _context.User
           .Include(x => x.UserRoles)
           .FirstOrDefault(x => x.UserId == userRoleModel.user.UserId);

            _context.TryUpdateManyToMany(user.UserRoles, userRoleModel.Roles
          .Select(x => new UserRole
          {
              RoleId = x,
              UserId = userRoleModel.user.UserId
          }), x => x.RoleId);

            _context.Attach(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return user;
                }
                else
                {
                    throw;
                }
            }

            return user;
        }
        public async Task<ActionResult<User>> PostUser(UserRoleModel userRoleModel)
        {
            var roleIds = userRoleModel.Roles;
            var roles = _context.Role.Where(x => roleIds.Contains(x.RoleId)).ToList();
            User user = userRoleModel.user;
            _context.Add(user);
            foreach (var item in roles)
            {
                _context.UserRole.Add(new UserRole
                {
                    User = user,
                    Role = item
                });
            }
            await _context.SaveChangesAsync();
            return user;
        }
        public List<Role> GetRoles(long[] roleIds)
        {
            return _context.Role.Where(x => roleIds.Contains(x.RoleId)).AsNoTracking().ToList();
        }
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return user;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public bool UserExists(long id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
