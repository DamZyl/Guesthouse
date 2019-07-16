using System;
using Guesthouse.Infrastructure.DTO;

namespace Guesthouse.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}