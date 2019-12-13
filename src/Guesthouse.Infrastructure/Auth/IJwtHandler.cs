using System;

namespace Guesthouse.Infrastructure.Auth
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string fullName, string role);
    }
}