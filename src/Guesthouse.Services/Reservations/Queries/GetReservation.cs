using Guesthouse.Services.Reservations.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Services.Reservations.Queries
{
    public class GetReservation : IQuery<ReservationDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
