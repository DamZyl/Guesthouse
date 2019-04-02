using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Infrastructure.DTO;

namespace Guesthouse.Infrastructure.Services
{
    public interface IReservationService
    {
        Task<ReservationDetailsDto> GetAsync(Guid id);
        Task<IEnumerable<ReservationDto>> GetAllAsync();
        Task<IEnumerable<ReservationDto>> GetForClient(Guid clientId);
        Task CreateAsync(Guid clientId, Guid id, string description,
                DateTime startReservation, DateTime endReservation);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, string description);
    }
}