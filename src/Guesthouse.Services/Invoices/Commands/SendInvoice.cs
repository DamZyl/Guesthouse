using System;
using Newtonsoft.Json;

namespace Guesthouse.Services.Invoices.Commands
{
    public class SendInvoice : ICommand
    {
        public Guid Id { get; set; }
        
        [JsonConstructor]
        public SendInvoice(Guid id)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
        }
    }
}