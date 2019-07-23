using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Infrastructure.DTO;

namespace Guesthouse.Infrastructure.Services
{
    public interface IReservationService : IService
    {
        Task<ReservationDetailsDto> GetAsync(Guid id);
        Task<IEnumerable<ReservationDto>> GetAllAsync();
        Task<IEnumerable<ReservationDto>> GetForClient(Guid clientId);
        Task CreateAsync(Guid clientId, Guid id, string description,
                DateTime startReservation, DateTime endReservation);
        Task ReservationPlaceAsync(Guid clientId, Guid id, IEnumerable<Room> rooms,
                IEnumerable<Convenience> conveniences); // TODO!!!
        //Task ReservationPlaceAsync(Guid clientId, Guid id, IEnumerable<Room> rooms); // TODO!!!
        Task CancelReservationPlaceAsync(Guid clientId, Guid id, IEnumerable<Room> rooms); // TODO!!!
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, string description);
    }
}