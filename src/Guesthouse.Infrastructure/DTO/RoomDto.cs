using System;

namespace Guesthouse.Infrastructure.DTO
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public decimal Price { get; set; }
        public DateTime? BookedAt { get; set; }
        public DateTime? BookedTo { get; set; }
        public Guid? ReservationId { get; set; }
        public bool Occupied { get; set; }
    }
}