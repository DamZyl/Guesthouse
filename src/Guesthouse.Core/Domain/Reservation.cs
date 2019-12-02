using System;
using System.Collections.Generic;
using System.Linq;
using Guesthouse.Core.Domain.Enums;
using Guesthouse.Core.Utils.Exceptions;

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
        public string Message { get; protected set; }
        public IEnumerable<Room> Rooms => _rooms;
        public IEnumerable<Convenience> Conveniences => _conveniences;

        protected Reservation()
        {
        }

        protected Reservation(Builder builder)
        {
            Id = builder.Id;
            Description = builder.Description;
            StartReservation = builder.StartReservation;
            EndReservation = builder.EndReservation;
            ReservationStatus = builder.ReservationStatus;
            PayStatus = builder.PayStatus;
        }

        //public static Reservation Create(Builder builder) => new Reservation(builder);

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException(ErrorCodes.InvalidDescription, "Description should not be empty.");
            }

            Description = description;
        }

        /*public void SetDates(DateTime startReservation, DateTime endReservation)
        {
            if (startReservation >= endReservation)
            {
                throw new DomainException(ErrorCodes.InvalidDate, "StartReservation should be earlier than EndReservation.");
            }

            StartReservation = startReservation;
            EndReservation = endReservation;
        }*/

        public void SetPayStatus(PayStatus payStatus)
        {
            if (PayStatus == payStatus || payStatus == PayStatus.NoPaid)
            {
                return;
            }

            PayStatus = payStatus;
        }

        public void ReservationPlace(Client client, IEnumerable<Room> rooms, IEnumerable<Convenience> conveniences)
        {
            if (client.PayType == PayWay.Prepayment)
            {
                PayStatus = PayStatus.Paid;
            }
            
            if (conveniences == null)
            {
                AddRooms(rooms);
                ClientId = client.Id;
                ClientName = client.GetFullName();
            }

            else
            {
                AddRooms(rooms);
                AddConveniences(conveniences);
                ClientId = client.Id;
                ClientName = client.GetFullName();    
            }

            client.SetReservationId(Id);
            Price = CalulatePrice();
        }

        public void CancelReservationPlace(Client client, IEnumerable<Room> rooms)
        {
            foreach (var room in rooms)
            {
                room.Cancel();
            }
            
            client.SetReservationId(null);
        }

        public void SendMessage(string message) => Message = message;

        public void ConfirmReservationStatus(ReservationStatus reservationStatus)
        {
            if (ReservationStatus == reservationStatus || reservationStatus == ReservationStatus.Unconfirmed)
            {
                return;
            }

            ReservationStatus = ReservationStatus.Confirmed;
        }

        private void AddRooms(IEnumerable<Room> rooms) 
        {
            foreach (var room in rooms)
            {
                if (room.Occupied) continue;
                
                room.Booked(this);
                _rooms.Add(room);
            }
        }
        
        private void AddConveniences(IEnumerable<Convenience> conveniences)
        {
            foreach (var convenience in conveniences)
            {
                _conveniences.Add(convenience);
            } 
        }

        private decimal CalulatePrice()
        {
            var reservationCost = _rooms.Sum(room => room.Price);

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

        public class Builder
        {
            internal Guid Id { get; set; }
            internal string Description { get; set; }
            internal DateTime StartReservation { get; set; }
            internal DateTime EndReservation { get; set; }
            internal ReservationStatus ReservationStatus { get; set; }
            internal PayStatus PayStatus { get; set; }

            public Builder WithId(Guid id)
            {
                Id = id;
                
                return this;
            }

            public Builder WithDescription(string description)
            {
                if (string.IsNullOrWhiteSpace(description))
                {
                    throw new DomainException(ErrorCodes.InvalidDescription, "Description should not be empty.");
                }

                Description = description;

                return this;
            }

            public Builder WithDates(DateTime startReservation, DateTime endReservation)
            {
                if (startReservation >= endReservation)
                {
                    throw new DomainException(ErrorCodes.InvalidDate, "StartReservation should be earlier than EndReservation.");
                }

                StartReservation = startReservation;
                EndReservation = endReservation;

                return this;
            }

            public Builder WithReservationStatus(ReservationStatus reservationStatus = ReservationStatus.Unconfirmed)
            {
                ReservationStatus = reservationStatus;
                
                return this;
            }

            public Builder WithPayStatus(PayStatus payStatus = PayStatus.NoPaid)
            {
                PayStatus = payStatus;

                return this;
            }
            
            public static Builder Create() => new Builder();
            public Reservation Build() => new Reservation(this);
        }
    }
}