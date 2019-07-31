using Guesthouse.Services.Invoices.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Services.Invoices.Queries
{
    public class GetInvoicesForClient : IQuery<IEnumerable<InvoiceDto>>
    {
        public Guid ClientId { get; set; }
    }
}
