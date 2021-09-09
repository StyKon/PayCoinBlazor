using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayCoin.Server.Models
{
    public class Provider
    {
        [Key]
        public long ProviderId { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string Phone2 { get; set; }
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
        public string Lat { get; set; }
        [Required]
        public string Long { get; set; }
        [Required]
        [RegularExpression("active|inactive", ErrorMessage = "Values must be between active and inactive")]
        public string Status { get; set; }

        public string Token { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<CategoryProvider> CategoryProviders { get; set; }
        public ICollection<ChildCategoryProvider> ChildCategoryProviders { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Coupon> Coupons { get; set; }
    }
}
