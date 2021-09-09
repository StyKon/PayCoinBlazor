using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Models
{
    public class ChildCategoryProvider
    {
        [Key]
        public long ChildCategoryProviderId { get; set; }
        [Required]
        public long ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public virtual Provider Provider { get; set; }
        [Required]
        public long ChildCategoryId { get; set; }
        [ForeignKey("ChildCategoryId")]
        public virtual ChildCategory ChildCategory { get; set; }
    }
}
