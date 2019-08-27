using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Users.Dto;
using Guesthouse.Services.Users.Queries;

namespace Guesthouse.Services.Users.Handlers
{
    public class GetEmployeeHandler : IQueryHandler<GetEmployee, AccountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<AccountDto> HandleAsync(GetEmployee query)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetOrFailAsync(query.Id);

            return _mapper.Map<AccountDto>(employee);
        }
    }
}