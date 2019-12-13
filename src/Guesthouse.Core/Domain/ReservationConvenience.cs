using System;

namespace Guesthouse.Core.Domain
{
    public class ReservationConvenience
    {
        public virtual Reservation Reservation { get; protected set; }
        public virtual Convenience Convenience { get; protected set; }

        public Guid ReservationId { get; protected set; }
        public Guid ConvenienceId { get; protected set; }
        public decimal? Cost { get; protected set; }

        protected ReservationConvenience() { }
        
        protected ReservationConvenience(Reservation reservation, Convenience convenience)
        {
            ReservationId = reservation.Id;
            ConvenienceId = convenience.Id;
            Cost = convenience.Cost;
        }
        
        public static ReservationConvenience Create(Reservation reservation, Convenience convenience)
            => new ReservationConvenience(reservation, convenience);
    }
}