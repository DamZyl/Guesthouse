using System;
using Newtonsoft.Json;

namespace Guesthouse.Services.Rooms.Commands
{
    public class UpdateRoom : ICommand
    {
        public Guid Id { get; set; }
        public bool IsBlock { get; set; }

        [JsonConstructor]
        public UpdateRoom(Guid id, bool isBlock)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            IsBlock = isBlock;
        }
    }
}