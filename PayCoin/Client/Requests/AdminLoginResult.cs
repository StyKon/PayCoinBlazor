using System.Text.Json.Serialization;
namespace PayCoin.Client.Requests
{
    public class AdminLoginResult
    {
        [JsonPropertyName("AdminId")]
        public long AdminId { get; set; }
        [JsonPropertyName("UserName")]
        public string UserName { get; set; }
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("Phone")]
        public string Phone { get; set; }
        [JsonPropertyName("Photo")]
        public string Photo { get; set; }
        [JsonPropertyName("Cin")]
        public string Cin { get; set; }
        [JsonPropertyName("Adresse")]
        public string Adresse { get; set; }
        [JsonPropertyName("City")]
        public string City { get; set; }
        [JsonPropertyName("Role")]
        public string Role { get; set; }
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }

    }
}
