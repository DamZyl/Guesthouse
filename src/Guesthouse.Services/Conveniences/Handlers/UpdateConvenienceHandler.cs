using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Conveniences.Commands;

namespace Guesthouse.Services.Conveniences.Handlers
{
    public class UpdateConvenienceHandler : ICommandHandler<UpdateConvenience>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateConvenienceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(UpdateConvenience command)
        {
            var convenience = await _unitOfWork.ConvenienceRepository.GetAsync(command.Id);
            convenience.SetIsBlock(command.IsBlock);

            await _unitOfWork.ConvenienceRepository.UpdateAsync(convenience);
            await _unitOfWork.Complete();
        }
    }
}