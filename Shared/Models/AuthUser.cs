
using System;

namespace ExampleApp.Shared.Models
{
    public class AuthUser
    {        
        public string UserName  { get; set; }        
        public string LastName { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
