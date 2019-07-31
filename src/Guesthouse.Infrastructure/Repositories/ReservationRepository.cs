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
    public class ReservationRepository : IReservationRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ReservationRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Reservation> GetAsync(Guid id)
            => await _databaseContext.Reservations.Include(p => p.Rooms)
                    .Include(p => p.Conveniences)
                    .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Reservation>> GetAllAsync()
            => await _databaseContext.Reservations.Include(p => p.Rooms)
                    .Include(p => p.Conveniences).ToListAsync();

        public async Task<IEnumerable<Reservation>> GetForClientAsync(Guid clientId)
            => await _databaseContext.Reservations.Where(x => x.ClientId == clientId)
                    .Include(p => p.Rooms).Include(p => p.Conveniences).ToListAsync();

        public async Task AddAsync(Reservation reservation)
            => await _databaseContext.Reservations.AddAsync(reservation);
        

        public async Task UpdateAsync(Reservation reservation)
            => _databaseContext.Reservations.Update(reservation);
        

        public async Task DeleteAsync(Reservation reservation)
            => _databaseContext.Reservations.Remove(reservation);
        
    }
}