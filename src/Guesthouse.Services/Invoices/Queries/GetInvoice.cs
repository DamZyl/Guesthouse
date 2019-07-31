using Guesthouse.Services.Invoices.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Services.Invoices.Queries
{
    public class GetInvoice : IQuery<InvoiceDto>
    {
        public Guid Id { get; set; }
    }
}
