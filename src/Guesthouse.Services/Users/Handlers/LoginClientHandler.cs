using System;
using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Auth;
using Guesthouse.Services.Users.Queries;

namespace Guesthouse.Services.Users.Handlers
{
    public class LoginClientHandler : IQueryHandler<LoginClient, TokenDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;

        public LoginClientHandler(IUnitOfWork unitOfWork, IJwtHandler jwtHandler)
        {
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
        }

        public async Task<TokenDto> HandleAsync(LoginClient query)
        {
            var client = await _unitOfWork.ClientRepository.GetAsync(query.Command.Email);

            if (client == null)
            {
                throw new Exception("Invalid creationals.");
            }

            if (client.Password != query.Command.Password)
            {
                throw new Exception("Invalid creationals.");
            }

            var jwt = _jwtHandler.CreateToken(client.Id, client.GetFullName(), client.ClientRole);

            return new TokenDto
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = client.ClientRole
            };
        }
    }
}