using System;
using System.Threading.Tasks;

namespace Guesthouse.Core.Repositories
{
    public interface IUnitOfWork : IRepository, IDisposable
    {
        IReservationRepository ReservationRepository { get; }
        IClientRepository ClientRepository { get; }
        IEmployeeRepository EmployeeRepository { get;  }
        IRoomRepository RoomRepository { get; }

        Task Complete();
    }
}