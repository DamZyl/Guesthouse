using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;

namespace Guesthouse.Core.Repositories
{
    public interface IRoomRepository : IRepository
    {
        Task<Room> GetAsync(Guid id);
        //Task<IEnumerable<Room>> GetOccupiedAsync();
        //Task<IEnumerable<Room>> GetAvailableAsync();
        //Task<IEnumerable<Room>> GetForReservationAsync(Guid id);
        Task<IEnumerable<Room>> GetAllAsync();
    }
}