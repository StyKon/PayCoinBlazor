using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PayCoin.Server.Requests
{
    public class DeliveryLoginResult
    {
        [JsonPropertyName("DeliveryId")]
        public long DeliveryId { get; set; }
        [JsonPropertyName("Slug")]
        public string Slug { get; set; }
        [JsonPropertyName("UserName")]
        public string UserName { get; set; }
        [JsonPropertyName("Firstname")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("CompanyName")]
        public string CompanyName { get; set; }
        [JsonPropertyName("Logo")]
        public string Logo { get; set; }
        [JsonPropertyName("Cin")]
        public string Cin { get; set; }
        [JsonPropertyName("Mc")]
        public string Mc { get; set; }
        [JsonPropertyName("Adresse")]
        public string Adresse { get; set; }
        [JsonPropertyName("City")]
        public string City { get; set; }
        [JsonPropertyName("Phone")]
        public string Phone { get; set; }
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }

    }
}
