using System;

namespace Guesthouse.Infrastructure.Auth
{
    public class JwtDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}