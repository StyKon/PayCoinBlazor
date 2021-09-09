using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Client.Models
{
    public class ChildCategory
    {
        [Key]
        public long ChildCategoryId { get; set; }
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
        [Required]
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public ICollection<SmallCategory> SmallCategorys { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ChildCategoryProvider> ChildCategoryProviders { get; set; }
    }
}
