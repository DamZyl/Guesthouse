using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Users.Commands;

namespace Guesthouse.Services.Users.Handlers
{
    public class UpdateAccountHandler : ICommandHandler<UpdateAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAccountHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(UpdateAccount command)
        {
            var client = await _unitOfWork.ClientRepository.GetAsync(command.Id);

            if (client != null)
            {
                client.SetEmail(command.Email);
                client.SetPassword(command.Password);

                await _unitOfWork.ClientRepository.UpdateAsync(client);
                await _unitOfWork.Complete();
            }

            else
            {
                var employee = await _unitOfWork.EmployeeRepository.GetAsync(command.Id);
                
                employee.SetEmail(command.Email);
                employee.SetPassword(command.Password);
                
                await _unitOfWork.EmployeeRepository.UpdateAsync(employee);
                await _unitOfWork.Complete();
            }
        }
    }
}