using System;

namespace Guesthouse.Services.Rooms.Dto
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public decimal Price { get; set; }
    }
}