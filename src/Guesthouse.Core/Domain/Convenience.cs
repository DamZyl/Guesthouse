using System;

namespace Guesthouse.Core.Domain
{
    public class Convenience
    {
        public virtual Reservation Reservation { get; protected set; }

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal? Cost { get; protected set; }

        protected Convenience()
        {
        }

        public Convenience(Guid id, string name, decimal? cost)
        {
            Id = id;
            SetName(name);
            SetCost(cost);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception();
            }

            if (Name == name)
            {
                return;
            }

            Name = name;
        }

        public void SetCost(decimal? cost)
        {
            if (cost <= 0)
            {
                throw new Exception();
            }

            Cost = cost;
        }
    }
}