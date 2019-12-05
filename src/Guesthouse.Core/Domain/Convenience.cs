using Guesthouse.Core.Utils.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Guesthouse.Core.Domain
{
    public class Convenience
    {
        private ISet<ReservationConvenience> _reservation = new HashSet<ReservationConvenience>();

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal? Cost { get; protected set; }
        public IEnumerable<ReservationConvenience> Reservations => _reservation;

        protected Convenience() { }

        protected Convenience(Guid id, string name, decimal? cost)
        {
            Id = id;
            SetName(name);
            SetCost(cost);
        }

        public static Convenience Create(Guid id, string name, decimal? cost)
            => new Convenience(id, name, cost);

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException(ErrorCodes.InvalidName, "Name should not be empty.");
            }

            if (Name == name)
            {
                return;
            }

            Name = name;
        }

        public void SetCost(decimal? cost)
        {
            if (cost != null && cost <= 0)
            {
                throw new DomainException(ErrorCodes.InvalidCost, "Cost should be greater than 0.");
            }

            Cost = cost;
        }
    }
}