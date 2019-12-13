using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;

namespace Guesthouse.Core.Repositories
{
    public interface IReservationRoomRepository : IRepository
    {
        Task<IEnumerable<ReservationRoom>> GetAllAsync();

        Task<ReservationRoom> GetAsync(Guid roomId);
        Task<IEnumerable<ReservationRoom>> GetByReservationAsync(Guid reservationId);
    }
}