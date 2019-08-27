using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Users.Commands;

namespace Guesthouse.Services.Users.Handlers
{
    public class RegisterClientHandler : ICommandHandler<RegisterClient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterClientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(RegisterClient command)
        {
            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(command.Email);

            client = Client.Create(command.Id, command.FirstName, command.LastName,
                command.Email, command.Password, command.PhoneNumber, command.PayType);

            await _unitOfWork.ClientRepository.AddAsync(client);
            await _unitOfWork.Complete();
        }
    }
}