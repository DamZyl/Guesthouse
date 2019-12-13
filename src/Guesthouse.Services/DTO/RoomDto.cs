using System;

namespace Guesthouse.Services.DTO
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public decimal Price { get; set; }
    }
}