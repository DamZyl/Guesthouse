using System.Collections.Generic;
using Guesthouse.Core.Domain;

namespace Guesthouse.Infrastructure.DTO
{
    public class ReservationDetailsDto : ReservationDto
    {
        public IEnumerable<RoomDto> Rooms { get; set; }
        public IEnumerable<ConvenienceDto> Conveniences { get; set; }
    }
}