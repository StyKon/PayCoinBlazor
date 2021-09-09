using System.ComponentModel.DataAnnotations;

namespace PayCoin.Client.Models
{
    public class Admin
    {
        [Key]
        public long AdminId { get; set; }
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

        [Required]
        [RegularExpression("admin|editor", ErrorMessage = "Values must be between admin and editor")]
        public string Role { get; set; }

        public string Token { get; set; }
    }
}
