using System;

namespace Guesthouse.Core.Domain
{
    public class ReservationRoom
    {
        public virtual Reservation Reservation { get; protected set; }
        public virtual Room Room { get; protected set; }

        public Guid ReservationId { get; protected set; }
        public Guid RoomId { get; protected set; }
        public DateTime BookedAt { get; protected set; } 
        public DateTime BookedTo { get; protected set; }
        public decimal Price { get; protected set; }

        protected ReservationRoom() { }
        
        protected ReservationRoom(Reservation reservation, Room room)
        {
            ReservationId = reservation.Id;
            BookedAt = reservation.StartReservation;
            BookedTo = reservation.EndReservation;
            RoomId = room.Id;
            Price = room.Price;
        }
        
        public static ReservationRoom Booked(Reservation reservation, Room room)
            => new ReservationRoom(reservation, room);
    }
}