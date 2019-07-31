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

        protected Invoice(Guid id, Guid clientId, Guid employeeId, Guid reservationId,
                DateTime issueDate, DateTime payDate)
        {
            Id = id;
            CompanyName = ConstValues.COMPANY_NAME;
            ClientId = clientId;
            EmployeeId = employeeId;
            ReservationId = reservationId;
            SetDates(issueDate, payDate);
        }

        public static Invoice Create(Guid id, Guid clientId, Guid employeeId, Guid reservationId,
                DateTime issueDate, DateTime payDate)
            => new Invoice(id, clientId, employeeId, reservationId,
                    issueDate, payDate);

        public void SetDates(DateTime issueDate, DateTime payDate)
        {
            if (issueDate > payDate)
            {
                throw new DomainException(ErrorCodes.InvalidDate, "IssueDate should be earlier than PayDate.");
            }

            IssueDate = issueDate;
            PayDate = payDate;
        }

        public void SetDetailsData(Client client, Employee employee, Reservation reservation)
        {
            if (client == null)
            {
                throw new DomainException(ErrorCodes.InvalidObject, "Client should not be null.");
            }

            if (employee == null)
            {
                throw new DomainException(ErrorCodes.InvalidObject, "Employee should not be null.");
            }

            if (reservation == null)
            {
                throw new DomainException(ErrorCodes.InvalidObject, "Reservation should not be null.");
            }

            ClientName = client.GetFullName();
            EmployeeName = employee.GetFullName();
            ReservationDescription = reservation.Description;
            MoneyToPay = reservation.Price;
        }
    }
}