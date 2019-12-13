using System;
using Newtonsoft.Json;

namespace Guesthouse.Services.Conveniences.Commands
{
    public class UpdateConvenience : ICommand
    {
        public Guid Id { get; set; }
        public bool IsBlock { get; set; }
        
        [JsonConstructor]
        public UpdateConvenience(Guid id, bool isBlock)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            IsBlock = isBlock;
        }
    }
}