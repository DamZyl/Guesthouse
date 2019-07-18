using System;
using System.Collections.Generic;
using System.Linq;
using Guesthouse.Core.Domain.Enums;

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
        public ReservationStatus ReservationStatus { get; protected set; }
        public PayStatus PayStatus { get; protected set; }
        public string Message { get; set; }
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
        }

        public static Reservation Create(Guid id, string description, DateTime startReservation,
                DateTime endReservation)
            => new Reservation(id, description, startReservation, endReservation);

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Description should not be empty.");
            }

            Description = description;
        }

        public void SetDates(DateTime startReservation, DateTime endReservation)
        {
            if (startReservation >= endReservation)
            {
                throw new Exception("StartReservation should be earlier than EndReservation.");
            }

            StartReservation = startReservation;
            EndReservation = endReservation;
        }

        // public void ReservationPlace(Client client, IEnumerable<Room> rooms, IEnumerable<Convenience> conveniences)
        // {
        //     if (conveniences == null)
        //     {
        //         AddRooms(rooms);
        //         ClientId = client.Id;
        //         ClientName = client.GetFullName();
        //     }

        //     else
        //     {
        //         AddRooms(rooms);
        //         AddConveniences(conveniences);
        //         ClientId = client.Id;
        //         ClientName = client.GetFullName();    
        //     }
        // }

        public void ReservationPlace(Client client, IEnumerable<Room> rooms) // Test version, because I think about Conveniences!!!
        {
            AddRooms(rooms);
            Price = CalulatePrice();
            ClientId = client.Id;
            ClientName = client.GetFullName();           
        }

        public void CancelReservationPlace(Client client, IEnumerable<Room> rooms)
        {
            foreach (var room in rooms)
            {
                room.Cancel();
            }
        }

        private void AddRooms(IEnumerable<Room> rooms) 
        {
            foreach (var room in rooms)
            {
                if (!room.Occupied)
                {
                    room.Booked(this);
                    _rooms.Add(room);    
                }
            }
        }

        // Think about db_FK(ReservationId) in Convenience may Intersection!!!
        private void AddConveniences(IEnumerable<Convenience> conveniences) // Check function!!!
        {
            //convenience.SetReservationId(Id); -> Think about this
            foreach (var convenience in conveniences)
            {
                _conveniences.Add(convenience);
            } 
        }

        private decimal CalulatePrice()
        {
            decimal reservationCost = 0;

            foreach (var room in _rooms)
            {
                reservationCost += room.Price;
            }

            foreach (var convenience in _conveniences)
            {
                if (convenience.Cost == null)
                {
                    reservationCost += 0;
                }

                else
                {
                    reservationCost += (decimal)convenience.Cost;
                }
            }

            return reservationCost;
        }
    }
}