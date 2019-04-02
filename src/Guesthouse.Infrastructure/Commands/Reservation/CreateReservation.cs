using System;

namespace Guesthouse.Infrastructure.Commands.Reservation
{
    public class CreateReservation
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime StartReservation { get; set; }
        public DateTime EndReservation { get; set; }
    }
}