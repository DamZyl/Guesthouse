using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Services.Invoices.Commands
{
    public class DeleteInvoice : ICommand
    {
        public Guid Id { get; set; }
    }
}
