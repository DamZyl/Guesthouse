using Guesthouse.Services.Reservations.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Services.Reservations.Queries
{
    public class GetReservations : IQuery<IEnumerable<ReservationDto>>
    {
    }
}
