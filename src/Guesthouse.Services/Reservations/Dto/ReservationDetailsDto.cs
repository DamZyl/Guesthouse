using System.Collections.Generic;
using Guesthouse.Services.Rooms.Dto;
using Guesthouse.Services.Conveniences.Dto;

namespace Guesthouse.Services.Reservations.Dto
{
    public class ReservationDetailsDto : ReservationDto
    {
        public IEnumerable<RoomDto> Rooms { get; set; }
        public IEnumerable<ConvenienceDto> Conveniences { get; set; }
    }
}