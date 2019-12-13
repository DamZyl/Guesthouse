using System;
using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Auth;
using Guesthouse.Services.Users.Queries;

namespace Guesthouse.Services.Users.Handlers
{
    public class LoginEmployeeHandler : IQueryHandler<LoginEmployee, TokenDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;

        public LoginEmployeeHandler(IUnitOfWork unitOfWork, IJwtHandler jwtHandler)
        {
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
        }
        
        public async Task<TokenDto> HandleAsync(LoginEmployee query)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetAsync(query.Command.Email);

            if (employee == null)
            {
                throw new Exception("Invalid creationals.");
            }

            if (employee.Password != query.Command.Password)
            {
                throw new Exception("Invalid creationals.");
            }

            var jwt = _jwtHandler.CreateToken(employee.Id, employee.GetFullName(), employee.EmployeeRole);

            return new TokenDto
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = employee.EmployeeRole
            };
        }
    }
}