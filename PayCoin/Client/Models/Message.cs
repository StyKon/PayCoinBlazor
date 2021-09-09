using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Client.Models
{
    public class Message
    {
        [Key]
        public long MessageId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Subject { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        [Required]
        public string MessageContent { get; set; }
        public string ReadAt { get; set; }


    }
}
