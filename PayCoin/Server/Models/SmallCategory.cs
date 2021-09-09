using Microsoft.EntityFrameworkCore;
using SlugGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Models
{
    public class SmallCategory : ISlug
    {
        [Key]
        public long SmallCategoryId { get; set; }
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
        public long ChildCategoryId { get; set; }
        [ForeignKey("ChildCategoryId")]
        public virtual ChildCategory ChildCategory { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
