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
        private ISet<ReservationRoom> _rooms = new HashSet<ReservationRoom>();
        private ISet<ReservationConvenience> _conveniences = new HashSet<ReservationConvenience>();

        public Guid Id { get; protected set; }
        public string Description { get; protected set; }
        public Guid? ClientId { get; protected set; }
        public string ClientName { get; protected set; }
        public decimal Price { get; protected set; }
        public DateTime StartReservation { get; protected set; }
        public DateTime EndReservation { get; protected set; }
        public ReservationStatus ReservationStatus { get; protected set; }
        public PayStatus PayStatus { get; protected set; }
        public string Message { get; protected set; }
        public IEnumerable<ReservationRoom> Rooms => _rooms;
        public IEnumerable<ReservationConvenience> Conveniences => _conveniences;

        protected Reservation() { }

        protected Reservation(Builder builder)
        {
            Id = builder.Id;
            Description = builder.Description;
            StartReservation = builder.StartReservation;
            EndReservation = builder.EndReservation;
            ReservationStatus = builder.ReservationStatus;
            PayStatus = builder.PayStatus;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException(ErrorCodes.InvalidDescription, "Description should not be empty.");
            }

            Description = description;
        }

        public void SetPayStatus(PayStatus payStatus)
        {
            if (PayStatus == payStatus || payStatus == PayStatus.NoPaid)
            {
                return;
            }

            PayStatus = payStatus;
        }

        public void ReservationPlace(Client client, IEnumerable<ReservationRoom> reservationRooms,
            IEnumerable<Room> rooms, IEnumerable<Convenience> conveniences)
        {
            if (client.PayType == PayWay.Prepayment)
            {
                PayStatus = PayStatus.Paid;
            }
            
            if (conveniences == null)
            { // refactor to function!!!
                foreach (var room in rooms)
                {
                    AddRooms(reservationRooms, room);    
                }
                
                ClientId = client.Id;
                ClientName = client.GetFullName();
            }

            else
            {
                foreach (var room in rooms)
                {
                    AddRooms(reservationRooms, room);    
                }

                foreach (var convenience in conveniences)
                {
                    AddConveniences(convenience);    
                }
                
                ClientId = client.Id;
                ClientName = client.GetFullName();    
            }

            client.SetReservationId(Id);
            Price = CalulatePrice();
        }

        public void CancelReservationPlace(Client client, IEnumerable<ReservationRoom> rooms)
        {
            for (var i = 0; i < rooms.Count() - 1; i++)
            {
                _rooms.Remove(rooms.ElementAt(i));
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

        private void AddRooms(IEnumerable<ReservationRoom> reservationRooms, Room room) 
        {
            foreach (var reservationRoom in reservationRooms)
            {
                if (!IsRoomAvailable(reservationRoom))
                {
                    throw new Exception("this room is booked");
                }
                
                _rooms.Add(ReservationRoom.Booked(this, room));
            }
        }
        
        private void AddConveniences(Convenience convenience)
        {
            _conveniences.Add(ReservationConvenience.Create(this, convenience));
        }

        private decimal CalulatePrice() // nie liczy!!!
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

        private bool IsRoomAvailable(ReservationRoom reservationRoom)
        {
            if (StartReservation < DateTime.Now)
                return false;

            if (StartReservation > reservationRoom.BookedAt && StartReservation > EndReservation && EndReservation > reservationRoom.BookedAt)
            {
                return false;
            }

            if (StartReservation < reservationRoom.BookedTo && EndReservation < reservationRoom.BookedTo && StartReservation > EndReservation)
            {
                return false;
            }

            return true;
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