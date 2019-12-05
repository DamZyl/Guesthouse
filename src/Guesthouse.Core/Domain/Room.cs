using Guesthouse.Core.Utils.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Guesthouse.Core.Domain
{
    public class Room
    {
        private ISet<ReservationRoom> _reservations = new HashSet<ReservationRoom>();

        public Guid Id { get; protected set; }
        public int Number { get; protected set; }
        public int Floor { get;  protected set; }
        public decimal Price { get; protected set; }
        public IEnumerable<ReservationRoom> Reservations => _reservations;

        protected Room() { }

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
    }
}