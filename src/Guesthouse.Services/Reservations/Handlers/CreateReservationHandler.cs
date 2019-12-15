using System.Collections.Generic;
using System.Linq;
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

            reservation = Reservation.Builder.Create()
                .WithId(command.Id)
                .WithDescription(command.Description)
                .WithDates(command.StartReservation, command.EndReservation)
                .WithReservationStatus()
                .WithPayStatus()
                .Build();

            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(command.UserId);
            var reservationRooms = await _unitOfWork.ReservationRoomRepository.GetAllAsync();

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
            reservation.ReservationPlace(client, reservationRooms, rooms, conveniences);

            await _unitOfWork.ReservationRepository.AddAsync(reservation);
            await _unitOfWork.Complete();
        }
    }
}