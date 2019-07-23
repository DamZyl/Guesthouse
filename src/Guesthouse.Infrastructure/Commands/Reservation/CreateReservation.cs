using System;
using System.Collections.Generic;
using Guesthouse.Core.Domain;

namespace Guesthouse.Infrastructure.Commands.Reservation
{
    public class CreateReservation
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime StartReservation { get; set; }
        public DateTime EndReservation { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Convenience> Conveniences { get; set; }
    }
}