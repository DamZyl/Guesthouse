using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Reservations.Commands;
using Guesthouse.Services.Services;

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

            var rooms = new HashSet<Room>();
            foreach (var id in command.Rooms)
            {
                rooms.Add(await _unitOfWork.RoomRepository.GetAsync(id));
            }
            
            var conveniences = new HashSet<Convenience>();
            foreach (var id in command.Conveniences)
            {
                conveniences.Add(await _unitOfWork.ConvenienceRepository.GetAsync(id));
            }
            
            reservation.ReservationPlace(client, rooms, conveniences);

            await _unitOfWork.ReservationRepository.AddAsync(reservation); 
            await _unitOfWork.Complete();
        }
    }
}