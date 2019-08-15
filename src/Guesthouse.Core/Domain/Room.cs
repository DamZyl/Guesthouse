using Guesthouse.Core.Utils.Exceptions;
using System;

namespace Guesthouse.Core.Domain
{
    public class Room
    {
        public virtual Reservation Reservation { get; protected set; }

        public Guid Id { get; protected set; }
        public int Number { get; protected set; }
        public int Floor { get;  protected set; }
        public decimal Price { get; protected set; }
        public DateTime? BookedAt { get; protected set; } 
        public DateTime? BookedTo { get; protected set; } 
        public Guid? ReservationId { get; protected set; }
        public bool Occupied => ReservationId.HasValue;

        protected Room()
        {
        }

        protected Room(Guid id, int number, int floor, decimal price)
        {
            Id = id;
            SetNumber(number);
            SetFloor(floor);
            SetPrice(price);
        }

        public static Room Create(Guid id, int number, int floor, decimal price)
            => new Room(id, number, floor, price); 

        public void SetNumber(int number)
        {
            if (number <= 0)
            {
                throw new DomainException(ErrorCodes.InvalidNumber, "Number shoud be greater than 0.");
            }

            if (Number == number)
            {
                return;
            }

            Number = number;
        }

         public void SetFloor(int floor)
        {
            if (floor < 0)
            {
                throw new DomainException(ErrorCodes.InvalidFloor, "Number shoud be 0 and greater.");
            }

            if (Floor == floor)
            {
                return;
            }

            Floor = floor;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new DomainException(ErrorCodes.InvalidPrice, "Price should be greater than 0.");
            }

            if (Price == price)
            {
                return;
            }

            Price = price;
        }

        public void Booked(Reservation reservation)
        {
            if (Occupied)
            {
                throw new DomainException(ErrorCodes.BookedRoom, "Room was already booked.");
            }

            ReservationId = reservation.Id;
            BookedAt = reservation.StartReservation;
            BookedTo = reservation.EndReservation;
        }

        public void Cancel()
        {
            if (!Occupied)
            {
                throw new DomainException(ErrorCodes.NotBookedRoom, "Room was not booked and can not be canceled.");
            }

            ReservationId = null;
            BookedAt = null;
            BookedTo = null;
        }
    }
}