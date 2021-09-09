﻿using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace PayCoin.Server.Models
{
    public class Designer
    {
        [Key]
        public long DesignerId { get; set; }
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
    }
}
