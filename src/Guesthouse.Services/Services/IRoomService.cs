using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Services.DTO;

namespace Guesthouse.Services.Services
{
    public interface IRoomService : IService
    {
        Task<IEnumerable<RoomDto>> GetOccupiedAsync();
        Task<IEnumerable<Room>> GetAvailableAsync();
        Task<IEnumerable<Room>> GetForReservationAsync(Guid id);
        Task<IEnumerable<RoomDto>> GetAllAsync();
    }
}