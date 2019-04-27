using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;

namespace Guesthouse.Core.Repositories
{
    public interface IReservationRepository : IRepository
    {
        // Add methods to Room and Converience!!!
        Task<Reservation> GetAsync(Guid id);
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<IEnumerable<Reservation>> GetForClient(Guid clientId);
        Task AddAsync(Reservation reservation);
        Task DeleteAsync(Reservation reservation);
        Task UpdateAsync(Reservation reservation);
    }
}