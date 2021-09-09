using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Client.Models
{
    public class Shipping
    {
        [Key]
        public long ShippingId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("active|inactive", ErrorMessage = "Values must be between active and inactive")]
        public string Status { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
