using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Infrastructure.DTO;

namespace Guesthouse.Infrastructure.Services
{
    public interface IRoomService : IService
    {
        Task<IEnumerable<RoomDto>> GetOccupiedAsync();
        Task<IEnumerable<Room>> GetAvailableAsync();
        Task<IEnumerable<Room>> GetForReservationAsync(Guid id);
        Task<IEnumerable<RoomDto>> GetAllAsync();
    }
}