using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Models
{
    public class Role
    {
        public Role()
        {
            UserRoles = new List<UserRole>();
        }
        public long RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
