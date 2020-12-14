
using System;

namespace ExampleApp.Shared.Models
{
    public class AuthToken
    {        
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
