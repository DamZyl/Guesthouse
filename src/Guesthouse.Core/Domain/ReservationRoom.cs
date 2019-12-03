using System;

namespace Guesthouse.Core.Domain
{
    public class ReservationRoom
    {
        public virtual Reservation Reservation { get; protected set; }
        public virtual Room Room { get; protected set; }

        public Guid ReservationId { get; protected set; }
        public Guid RoomId { get; protected set; }

        protected ReservationRoom() { }
        
        protected ReservationRoom(Reservation reservation, Room room)
        {
            ReservationId = reservation.Id;
            RoomId = room.Id;
        }
        
        public static ReservationRoom Create(Reservation reservation, Room room)
            => new ReservationRoom(reservation, room);
    }
}