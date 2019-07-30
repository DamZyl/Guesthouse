using Guesthouse.Core.Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Services.Reservations.Commands
{
    public class UpdateReservation : ICommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public PayStatus PayStatus { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public string Message { get; set; }

        [JsonConstructor]
        public UpdateReservation(Guid id, string description, PayStatus payStatus,
                ReservationStatus reservationStatus, string message)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Description = description;
            PayStatus = payStatus;
            ReservationStatus = reservationStatus;
            Message = message;
        }
    }
}
