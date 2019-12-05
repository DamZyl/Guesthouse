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
    public class ReservationRoomRepository : IReservationRoomRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ReservationRoomRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<ReservationRoom>> GetAllAsync()
            => await _databaseContext.ReservationRooms.ToListAsync();

        public async Task<ReservationRoom> GetAsync(Guid roomId)
            => await _databaseContext.ReservationRooms.SingleOrDefaultAsync(x => x.RoomId == roomId);

        public async Task AddAsync(ReservationRoom reservationRoom)
            => await _databaseContext.ReservationRooms.AddAsync(reservationRoom);
    }
}