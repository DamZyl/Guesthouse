using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;

namespace Guesthouse.Core.Repositories
{
    public interface IReservationConvenienceRepository : IRepository
    {
        Task<IEnumerable<ReservationConvenience>> GetAllAsync();
        Task<ReservationConvenience> GetAsync(Guid convenienceId);
        Task AddAsync(ReservationConvenience reservationConvenience);
    }
}