using System;
using System.Collections.Generic;
using Guesthouse.Core.Domain;
using Guesthouse.Services.DTO;
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
        public IEnumerable<Guid> Rooms { get; set; }
        public IEnumerable<Guid> Conveniences { get; set; }
        
        [JsonConstructor]
        public CreateReservation(Guid id, string description, DateTime startReservation, DateTime endReservation,
            IEnumerable<Guid> rooms, IEnumerable<Guid> conveniences)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            UserId = Guid.Empty;
            Description = description;
            StartReservation = startReservation;
            EndReservation = endReservation;
            Rooms = rooms;
            Conveniences = conveniences;
        }
    }
}