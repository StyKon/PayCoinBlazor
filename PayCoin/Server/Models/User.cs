using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayCoin.Server.Models
{
    public class User 
    {
        [Key]
        public long UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Cin { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression("active|inactive", ErrorMessage = "Values must be between active and inactive")]
        public string Status { get; set; }

        public string Token { get; set; }
         public User()
       {
            UserRoles = new List<UserRole>();
       }
       public virtual ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<WhishList> WhishLists { get; set; }
    }
}
