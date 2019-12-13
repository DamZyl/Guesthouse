using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;

namespace Guesthouse.Core.Repositories
{
    public interface IRoomRepository : IRepository
    {
        Task<Room> GetAsync(Guid id);
        Task<IEnumerable<Room>> GetAllAsync();
        IEnumerable<Room> GetAll();
        Task UpdateAsync(Room room);
    }
}
