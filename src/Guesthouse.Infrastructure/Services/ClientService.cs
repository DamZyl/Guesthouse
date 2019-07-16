using System;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.DTO;
using Guesthouse.Infrastructure.Extensions;

namespace Guesthouse.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IJwtHandler jwtHandler, 
                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }
        
        public async Task<AccountDto> GetAccountAsync(Guid clientId)
        {
            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(clientId);

            return _mapper.Map<AccountDto>(client);
        }

        public async Task<TokenDto> LoginAsync(string email, string password)
        {
            var client = await _unitOfWork.ClientRepository.GetAsync(email);

            if (client == null)
            {
                throw new Exception("Invalid creationals.");
            }

            if (client.Password != password)
            {
                throw new Exception("Invalid creationals.");
            }

            var jwt = _jwtHandler.CreateToken(client.Id, client.ClientRole);

            return new TokenDto
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = client.ClientRole
            };
        }

        public async Task RegisterAsync(Guid id, string firstName, string lastName, string email,
            string password, string phoneNumber, PayWay payType)
        {
            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(email);

            client = Client.Create(id, firstName, lastName, email, password, phoneNumber, payType);

            await _unitOfWork.ClientRepository.AddAsync(client);
            await _unitOfWork.Complete();
        }
    }
}