using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Services.Invoices.Commands
{
    public class CreateInvoice : ICommand
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ReservationId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PayDate { get; set; }

        [JsonConstructor]
        public CreateInvoice(Guid id, Guid clientId, Guid employeeId, Guid reservationId, DateTime issueDate, DateTime payDate)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            ClientId = clientId;
            EmployeeId = employeeId;
            ReservationId = reservationId;
            IssueDate = issueDate;
            PayDate = payDate;
        }
    }
}
