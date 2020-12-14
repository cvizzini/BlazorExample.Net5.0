using Newtonsoft.Json;
using System;

namespace ExampleApp.Tester
{
    internal sealed class AuthToken
    {
        [JsonProperty("token")] // using Newtonsoft.Json => JsonProperty;
        public string Token { get; set; }


        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
    }
}
