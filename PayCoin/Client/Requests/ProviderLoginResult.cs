using System.Text.Json.Serialization;
namespace PayCoin.Client.Requests
{
    public class ProviderLoginResult
    {
        public long ProviderId { get; set; }
        public string Slug { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Logo { get; set; }
        public string Cin { get; set; }
        public string Mc { get; set; }
        public string Adresse { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
