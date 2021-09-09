using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Models
{
    public class Notification
    {
        [Key]
        public long NotificationId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Notifiable { get; set; }
        [Required]
        public string Data { get; set; }
        public string ReadAt { get; set; }
    }
}
