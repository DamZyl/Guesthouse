using Guesthouse.Services.Reservations.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Services.Reservations.Queries
{
    public class GetReservationsForClient : IQuery<IEnumerable<ReservationDto>>
    {
        public Guid ClientId { get; set; }
    }
}
