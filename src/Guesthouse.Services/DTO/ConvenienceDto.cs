using System;

namespace Guesthouse.Services.DTO
{
    public class ConvenienceDto
    {
        public Guid Id { get; set; }
        public Guid? ReservationId { get; set;}
        public string Name { get; set; }
        public decimal? Cost { get; set; }
    }
}