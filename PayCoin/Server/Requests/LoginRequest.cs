using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PayCoin.Server.Requests
{
    public class LoginRequest
    {
        [Required]
        [JsonPropertyName("Phone")]
        public string Phone { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
