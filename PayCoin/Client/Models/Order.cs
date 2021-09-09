using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Client.Models
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public double SubTotal { get; set; }
        public double Coupon { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public int Quantity { get; set; }
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
        public string Country { get; set; }
        [Required]
        public string Adresse1 { get; set; }
        [Required]
        public string Adresse2 { get; set; }


        [Required]
        [RegularExpression("cod|paypal", ErrorMessage = "Values must be between cod and paypal")]
        public string PaymentMethod { get; set; }

        [Required]
        [RegularExpression("paid|unpaid", ErrorMessage = "Values must be between paid and unpaid")]
        public string PaymentStatus { get; set; }
        [Required]
        [RegularExpression("new|process|delivered|cancel", ErrorMessage = "Values must be between new and process and delivered and cancel")]
        public string Status { get; set; }
  
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public long ShippingId { get; set; }
        [ForeignKey("ShippingId")]
        public virtual Shipping Shipping { get; set; }
        public ICollection<Cart> Carts { get; set; }
       
    }
}
