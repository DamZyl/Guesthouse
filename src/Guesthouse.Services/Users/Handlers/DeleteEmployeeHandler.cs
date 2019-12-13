using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Users.Commands;

namespace Guesthouse.Services.Users.Handlers
{
    public class DeleteEmployeeHandler : ICommandHandler<DeleteEmployee>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(DeleteEmployee command)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetOrFailAsync(command.Id);
            
            await _unitOfWork.EmployeeRepository.DeleteAsync(employee);
            await _unitOfWork.Complete();
        }
    }
}