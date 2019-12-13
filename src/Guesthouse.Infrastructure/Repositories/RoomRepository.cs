using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Guesthouse.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RoomRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
            => await _databaseContext.Rooms.ToListAsync();
        
        public IEnumerable<Room> GetAll()
            => _databaseContext.Rooms.ToList();

        public async Task<Room> GetAsync(Guid id)
            => await _databaseContext.Rooms.SingleOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Room room)
        {
            _databaseContext.Rooms.Update(room);
            await Task.CompletedTask;
        }
    }
}