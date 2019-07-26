using System.Collections.Generic;
using Guesthouse.Core.Domain;
using Guesthouse.Services.DTO;

namespace Guesthouse.Services.Reservations.Dto
{
    public class ReservationDetailsDto : ReservationDto
    {
        public IEnumerable<RoomDto> Rooms { get; set; }
        public IEnumerable<ConvenienceDto> Conveniences { get; set; }
    }
}