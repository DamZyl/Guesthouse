using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Guesthouse.Infrastructure.Repositories
{
    public class ReservationConvenienceRepository : IReservationConvenienceRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ReservationConvenienceRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<ReservationConvenience>> GetAllAsync()
            => await _databaseContext.ReservationConveniences.ToListAsync();

        public async Task<ReservationConvenience> GetAsync(Guid convenienceId)
            => await _databaseContext.ReservationConveniences.SingleOrDefaultAsync(x => x.ConvenienceId == convenienceId);

        public async Task AddAsync(ReservationConvenience reservationConvenience)
            => await _databaseContext.ReservationConveniences.AddAsync(reservationConvenience);
    }
}