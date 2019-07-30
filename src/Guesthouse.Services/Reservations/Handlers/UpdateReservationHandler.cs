using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Reservations.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guesthouse.Services.Reservations.Handlers
{
    public class UpdateReservationHandler : ICommandHandler<UpdateReservation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateReservationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(UpdateReservation command)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetOrFailAsync(command.Id);

            reservation.SetDescription(command.Description);
            reservation.SetPayStatus(command.PayStatus);
            reservation.ConfirmReservationStatus(command.ReservationStatus);
            reservation.SendMessage(command.Message);

            await _unitOfWork.ReservationRepository.UpdateAsync(reservation);
            await _unitOfWork.Complete();
        }
    }
}
