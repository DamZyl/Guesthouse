using System;
using System.Collections.Generic;

namespace Guesthouse.Core.Domain
{
    public class Reservation
    {
        public virtual Invoice Invoice { get; protected set; }
        public virtual Client Client { get; protected set; }
        private ISet<Room> _rooms = new HashSet<Room>();
        private ISet<Convenience> _conveniences = new HashSet<Convenience>();

        public Guid Id { get; protected set; }
        public string Description { get; protected set; }
        public Guid ClientId { get; protected set; }
        public string ClientName { get; protected set; }
        public decimal Price { get; protected set; }
        public IEnumerable<Room> Rooms => _rooms;
        public IEnumerable<Convenience> Conveniences => _conveniences;

        protected Reservation()
        {
        }

        public Reservation(Guid id, string description, Guid clientId, string clientName)
        {
            Id = id;
            SetDescription(description);
            ClientId = clientId;
            ClientName = clientName;
            Price = CalulatePrice(); 
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception();
            }

            Description = description;
        }

        private decimal CalulatePrice()
        {
            return 0;
        }
    }
}