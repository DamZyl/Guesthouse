using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Users.Commands;

namespace Guesthouse.Services.Users.Handlers
{
    public class DeleteClientHandler : ICommandHandler<DeleteClient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(DeleteClient command)
        {
            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(command.Id);
            
            await _unitOfWork.ClientRepository.DeleteAsync(client);
            await _unitOfWork.Complete();
        }
    }
}