using PayCoin.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Client.Models
{
    public class Cart
    {
        [Key]
        public long CartId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required]
        [RegularExpression("new|progress|delivered|cancel", ErrorMessage = "Values must be between new and progress and delivered andcancel")]
        public string Status { get; set; }
        [Required]
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public long OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public long ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public virtual Provider Provider { get; set; }

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public ICollection<WhishList> WhishLists { get; set; }



    }
}
