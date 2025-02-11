﻿using System.Text.Json.Serialization;

namespace PayCoin.Client.Requests
{
    public class LoginResult
    {
        
        public long UserId { get; set; }
       
        public string UserName { get; set; }
       
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
       
        public string Email { get; set; }
     
        public string Photo { get; set; }
      
        public string Cin { get; set; }
        
        public string Adresse { get; set; }
 
        public string City { get; set; }
      
        public string Phone { get; set; }
     
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
