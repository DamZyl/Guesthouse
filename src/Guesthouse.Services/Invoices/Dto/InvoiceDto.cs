using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Services.Invoices.Dto
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string ClientName { get; set; }
        public string EmployeeName { get; set; }
        public string ReservationDescription { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PayDate { get; set; }
        public decimal MoneyToPay { get; set; }
    }
}
