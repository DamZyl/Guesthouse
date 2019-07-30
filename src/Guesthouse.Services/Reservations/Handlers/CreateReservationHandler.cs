using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Reservations.Commands;

namespace Guesthouse.Services.Reservations.Handlers
{
    public class CreateReservationHandler : ICommandHandler<CreateReservation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReservationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(CreateReservation command)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetAsync(command.Id);

            reservation = Reservation.Create(command.Id, command.Description,
                    command.StartReservation, command.EndReservation);

            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(command.UserId);

            var rooms = await _unitOfWork.RoomRepository.GetAvailableAsync(); // Test delete later!!!
            var conveniences = await _unitOfWork.ConvenienceRepository.GetAllAsync(); // Test delete later!!!

            reservation.ReservationPlace(client, rooms, conveniences);

            await _unitOfWork.ReservationRepository.AddAsync(reservation); 
            await _unitOfWork.Complete();
        }
    }
}