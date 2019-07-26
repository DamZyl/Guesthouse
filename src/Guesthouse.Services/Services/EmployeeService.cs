using System;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Auth;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Users.Dto;

namespace Guesthouse.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IJwtHandler jwtHandler, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }
        
        public async Task<AccountDto> GetAccountAsync(Guid employeeId)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetOrFailAsync(employeeId);

            return _mapper.Map<AccountDto>(employee);
        }

        public async Task<TokenDto> LoginAsync(string email, string password)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetAsync(email);

            if (employee == null)
            {
                throw new Exception("Invalid creationals.");
            }

            if (employee.Password != password)
            {
                throw new Exception("Invalid creationals.");
            }

            var jwt = _jwtHandler.CreateToken(employee.Id, employee.EmployeeRole);

            return new TokenDto
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = employee.EmployeeRole
            };
        }

        public async Task RegisterAsync(Guid id, string firstName, string lastName, string email,
            string password, string role)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetOrFailAsync(email);

            employee = Employee.Create(id, firstName, lastName, email, password, role);

            await _unitOfWork.EmployeeRepository.AddAsync(employee);
            await _unitOfWork.Complete();
        }
    }
}