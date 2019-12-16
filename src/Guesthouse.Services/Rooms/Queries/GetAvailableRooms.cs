using System.Collections.Generic;
using Guesthouse.Services.Rooms.Dto;

namespace Guesthouse.Services.Rooms.Queries
{
    public class GetAvailableRooms : IQuery<IEnumerable<RoomDto>>
    {
    }
}