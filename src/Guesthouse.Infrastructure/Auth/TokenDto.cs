using System;

namespace Guesthouse.Infrastructure.Auth
{
    public class TokenDto
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public DateTime Expires { get; set; }
    }
}