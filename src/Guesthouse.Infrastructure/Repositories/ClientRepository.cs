using System;
using System.Linq;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Guesthouse.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ClientRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Client> GetAsync(Guid id)
            => await _databaseContext.Clients.SingleOrDefaultAsync(x => x.Id == id);
    }
}