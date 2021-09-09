using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayCoin.Client.Models
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string Slug { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        [RegularExpression("active|inactive", ErrorMessage = "Values must be between active and inactive")]
        public string Status { get; set; }
        public ICollection<ChildCategory> ChildCategorys { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<CategoryProvider> CategoryProviders { get; set; }

    }
}
