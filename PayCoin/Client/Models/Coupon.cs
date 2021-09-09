using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Client.Models
{
    public class Coupon
    {
        [Key]
        public long CouponId { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public double Value { get; set; }

        [Required]
        public string DateValidation { get; set; }
        [Required]
        public string DateExpired { get; set; }

        
        [Required]
        [RegularExpression("fixed|percent", ErrorMessage = "Values must be between fixed and percent")]
        public string Type { get; set; }

        [Required]
        [RegularExpression("real|virtual", ErrorMessage = "Values must be between real and virtual")]
        public string Nature { get; set; }
        [Required]
        [RegularExpression("valid|invalid", ErrorMessage = "Values must be between real and virtual")]
        public string Validation { get; set; }
        [Required]
        [RegularExpression("active|inactive", ErrorMessage = "Values must be between active and inactive")]
        public string Status { get; set; }
        public long ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public virtual Provider Provider { get; set; }
        public long CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public virtual Community Community { get; set; }
    }
}
