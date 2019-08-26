using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Users.Dto;
using Guesthouse.Services.Users.Queries;

namespace Guesthouse.Services.Users.Handlers
{
    public class GetClientHandler : IQueryHandler<GetClient, AccountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AccountDto> HandleAsync(GetClient query)
        {
            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(query.Id);

            return _mapper.Map<AccountDto>(client);
        }
    }
}