using System;
using System.Collections.Generic;
using Guesthouse.Core.Domain;
using Newtonsoft.Json;

namespace Guesthouse.Services.Reservations.Commands
{
    public class CreateReservation : ICommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime StartReservation { get; set; }
        public DateTime EndReservation { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Convenience> Conveniences { get; set; }
        
        [JsonConstructor]
        public CreateReservation(Guid id, string description, DateTime startReservation, DateTime endReservation)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            UserId = Guid.Empty;
            Description = description;
            StartReservation = startReservation;
            EndReservation = endReservation;
        }
    }
}