using System;
using System.Collections.Generic;

namespace Guesthouse.Core.Domain
{
    public class Reservation
    {
        public virtual Invoice Invoice { get; protected set; }
        public virtual Client Client { get; protected set; }
        private ISet<Room> _rooms = new HashSet<Room>();
        private ISet<Convenience> _conveniences = new HashSet<Convenience>();

        public Guid Id { get; protected set; }
        public string Description { get; protected set; }
        public Guid ClientId { get; protected set; }
        public string ClientName { get; protected set; }
        public decimal Price { get; protected set; }
        public DateTime StartReservation { get; protected set; }
        public DateTime EndReservation { get; protected set; }
        public IEnumerable<Room> Rooms => _rooms;
        public IEnumerable<Convenience> Conveniences => _conveniences;

        protected Reservation()
        {
        }

        protected Reservation(Guid id, string description, DateTime startReservation,
                DateTime endReservation)
        {
            Id = id;
            SetDescription(description);
            SetDates(startReservation, endReservation);
            Price = CalulatePrice(); 
        }

        public static Reservation Create(Guid id, string description, DateTime startReservation,
                DateTime endReservation)
            => new Reservation(id, description, startReservation, endReservation);

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception();
            }

            Description = description;
        }

        public void SetDates(DateTime startReservation, DateTime endReservation)
        {
            if (startReservation >= endReservation)
            {
                throw new Exception();
            }

            StartReservation = startReservation;
            EndReservation = endReservation;
        }

        public void ReservationPlace(Client client) // TODO!!!
        {
            ClientId = client.Id;
            ClientName = client.GetFullName();
        }

        private decimal CalulatePrice() // TODO!!!
        {
            return 0;
        }
    }
}