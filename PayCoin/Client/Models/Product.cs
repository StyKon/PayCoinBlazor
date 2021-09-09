using PayCoin.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Client.Models
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        public string Slug { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        [RegularExpression("default|new|hot|rec", ErrorMessage = "Values must be between default and new and hot and rec")]
        public string Condiction { get; set; }
        [Required]
        public double Price { get; set; }
        public double Discount { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        [RegularExpression("active|inactive", ErrorMessage = "Values must be between active and inactive")]
        public string Status { get; set; }
        [Required]
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [Required]
        public long ChildCategoryId { get; set; }
        [ForeignKey("ChildCategoryId")]
        public virtual ChildCategory ChildCategory { get; set; }
        [Required]
        public long SmallCategoryId { get; set; }
        [ForeignKey("SmallCategoryId")]
        public virtual SmallCategory SmallCategory { get; set; }
        [Required]
        public long ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public virtual Provider Provider { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<WhishList> WhishLists { get; set; }
    }
}
