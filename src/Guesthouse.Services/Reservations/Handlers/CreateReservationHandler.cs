using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
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
           
            await _unitOfWork.ReservationRepository.AddAsync(reservation); 
            await _unitOfWork.Complete();
        }
    }
}