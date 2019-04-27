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
        Task<IEnumerable<Room>> GetAvailableAsync(); // DTO
        Task<IEnumerable<Room>> GetForReservationAsync(Guid id); // DTO
        Task<IEnumerable<RoomDto>> GetAllAsync();
    }
}