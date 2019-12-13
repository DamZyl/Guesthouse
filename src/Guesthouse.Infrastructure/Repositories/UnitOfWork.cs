using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Database;

namespace Guesthouse.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext; 
        public IReservationRepository ReservationRepository { get; }
        public IClientRepository ClientRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IRoomRepository RoomRepository { get; }
        public IConvenienceRepository ConvenienceRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }
        public IReservationRoomRepository ReservationRoomRepository { get; }
        public IReservationConvenienceRepository ReservationConvenienceRepository { get; }

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            ReservationRepository = new ReservationRepository(_databaseContext);
            ClientRepository = new ClientRepository(_databaseContext);
            EmployeeRepository = new EmployeeRepository(_databaseContext);
            RoomRepository = new RoomRepository(_databaseContext);
            ConvenienceRepository = new ConvenienceRepository(_databaseContext);
            InvoiceRepository = new InvoiceRepository(_databaseContext);
            ReservationRoomRepository = new ReservationRoomRepository(_databaseContext);
            ReservationConvenienceRepository = new ReservationConvenienceRepository(_databaseContext);
        }

        public async Task Complete()
            => await _databaseContext.SaveChangesAsync();

        public void Dispose()
            => _databaseContext.Dispose();
    }
}