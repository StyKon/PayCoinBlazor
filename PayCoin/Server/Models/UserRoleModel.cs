using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Models
{
    public class UserRoleModel
    {
        public User user { get; set; }
        public IEnumerable<long> Roles { get; set; }

    }
}
