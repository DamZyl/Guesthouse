using System;
using System.Collections.Generic;
using Guesthouse.Core.Utils;
using Guesthouse.Core.Utils.Exceptions;

namespace Guesthouse.Core.Domain
{
    public class Invoice
    {
        public virtual Employee Employee { get; protected set; }
        public virtual Client Client { get; protected set; }
        public virtual Reservation Reservation { get; protected set; }

        public Guid Id { get; protected set; }
        public string CompanyName { get; protected set; }
        public Guid ClientId { get; protected set; }
        public string ClientName { get; protected set; }
        public Guid EmployeeId { get; protected set; }
        public string EmployeeName { get; protected set; }
        public Guid ReservationId { get; protected set; }
        public string ReservationDescription { get; protected set; }
        public DateTime IssueDate { get; protected set; }
        public DateTime PayDate { get; protected set; }
        public decimal MoneyToPay { get; protected set; }

        protected Invoice()
        {
        }

        protected Invoice(Guid id, Guid clientId, string clientName, Guid employeeId,
                string employeeName, Guid reservationId, string reservationDescription,
                DateTime issueDate, DateTime payDate, decimal moneyToPay)
        {
            Id = id;
            CompanyName = ConstValues.COMPANY_NAME;
            ClientId = clientId;
            ClientName = clientName;
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            ReservationId = reservationId;
            ReservationDescription = reservationDescription;
            SetDates(issueDate, payDate);
            MoneyToPay = moneyToPay;
        }

        public static Invoice Create(Guid id, Guid clientId, string clientName, Guid employeeId,
                string employeeName, Guid reservationId, string reservationDescription,
                DateTime issueDate, DateTime payDate, decimal moneyToPay)
            => new Invoice(id, clientId, clientName, employeeId, employeeName, reservationId,
                    reservationDescription, issueDate, payDate, moneyToPay);

        public void SetDates(DateTime issueDate, DateTime payDate)
        {
            if (issueDate > payDate)
            {
                throw new DomainException(ErrorCodes.InvalidDate, "IssueDate should be earlier than PayDate.");
            }

            IssueDate = issueDate;
            PayDate = payDate;
        }
    }
}