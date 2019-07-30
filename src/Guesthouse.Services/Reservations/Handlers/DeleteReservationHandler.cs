using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Reservations.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guesthouse.Services.Reservations.Handlers
{
    public class DeleteReservationHandler : ICommandHandler<DeleteReservation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReservationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeleteReservation command)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetOrFailAsync(command.Id);
            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(command.UserId);
            var rooms = await _unitOfWork.RoomRepository.GetForReservationAsync(command.Id);

            reservation.CancelReservationPlace(client, rooms);

            await _unitOfWork.ReservationRepository.DeleteAsync(reservation);
            await _unitOfWork.Complete();
        }
    }
}
