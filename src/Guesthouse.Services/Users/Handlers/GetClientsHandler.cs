using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Users.Dto;
using Guesthouse.Services.Users.Queries;

namespace Guesthouse.Services.Users.Handlers
{
    public class GetClientsHandler : IQueryHandler<GetClients, IEnumerable<AccountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClientsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<AccountDto>> HandleAsync(GetClients query)
        {
            var clients = await _unitOfWork.ClientRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AccountDto>>(clients);
        }
    }
}