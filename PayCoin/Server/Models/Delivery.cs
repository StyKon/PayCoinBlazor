using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Models
{
    public class Delivery
    {
        [Key]
        public long DeliveryId { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string CompanyName { get; set; }
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
        [Required]
        public string Logo { get; set; }
        public string Cin { get; set; }
        public string Mc { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        [RegularExpression("active|inactive", ErrorMessage = "Values must be between active and inactive")]
        public string Status { get; set; }

        public string Token { get; set; }
    }
}
