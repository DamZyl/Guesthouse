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
    public class ClientRepository : IClientRepository 
    {
        private readonly DatabaseContext _databaseContext;

        public ClientRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Client> GetAsync(Guid id)
            => await _databaseContext.Clients.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Client> GetAsync(string email)
            => await _databaseContext.Clients.SingleOrDefaultAsync(x => x.Email == email);
        public async Task<IEnumerable<Client>> GetAllAsync()
            => await _databaseContext.Clients.ToListAsync();

        public async Task AddAsync(Client client)
            => await _databaseContext.Clients.AddAsync(client);

        public async Task UpdateAsync(Client client)
        {
            _databaseContext.Clients.Update(client);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Client client)
        {
            _databaseContext.Clients.Remove(client);
            await Task.CompletedTask;
        }
    }
}