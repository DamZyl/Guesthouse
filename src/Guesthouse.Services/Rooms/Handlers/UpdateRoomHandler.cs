using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Rooms.Commands;

namespace Guesthouse.Services.Rooms.Handlers
{
    public class UpdateRoomHandler : ICommandHandler<UpdateRoom>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoomHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(UpdateRoom command)
        {
            var room = await _unitOfWork.RoomRepository.GetAsync(command.Id);
            room.SetIsBlock(command.IsBlock);

            await _unitOfWork.RoomRepository.UpdateAsync(room);
            await _unitOfWork.Complete();
        }
    }
}