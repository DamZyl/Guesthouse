using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Users.Dto;
using Guesthouse.Services.Users.Queries;

namespace Guesthouse.Services.Users.Handlers
{
    public class GetEmployeesHandler : IQueryHandler<GetEmployees, IEnumerable<AccountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetEmployeesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<AccountDto>> HandleAsync(GetEmployees query)
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AccountDto>>(employees);
        }
    }
}