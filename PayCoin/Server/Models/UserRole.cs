using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Models
{
   public class UserRole
    {
        [Key]
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
