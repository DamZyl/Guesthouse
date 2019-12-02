using Guesthouse.Infrastructure.Auth;
using Guesthouse.Services.Users.Commands;

namespace Guesthouse.Services.Users.Queries
{
    public class LoginEmployee : IQuery<TokenDto>
    {
        public Login Command { get; set; }
    }
}