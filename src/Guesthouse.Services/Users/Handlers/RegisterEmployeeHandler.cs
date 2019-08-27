using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Users.Commands;

namespace Guesthouse.Services.Users.Handlers
{
    public class RegisterEmployeeHandler : ICommandHandler<Register>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterEmployeeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(Register command)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetOrFailAsync(command.Email);

            employee = Employee.Create(command.Id, command.FirstName, command.LastName,
                command.Email, command.Password, command.EmployeeRole);

            await _unitOfWork.EmployeeRepository.AddAsync(employee);
            await _unitOfWork.Complete();
        }
    }
}