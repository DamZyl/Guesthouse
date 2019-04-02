using System;
using System.Collections.Generic;
using Guesthouse.Core.Domain;

namespace Guesthouse.Infrastructure.DTO
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public decimal Price { get; set; }
        public DateTime StartReservation { get; set; }
        public DateTime EndReservation { get; set; }
        public int RoomsCount { get; set; }
    }
}