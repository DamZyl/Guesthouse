using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Guesthouse.Infrastructure.Repositories
{
    public class ConvenienceRepository : IConvenienceRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ConvenienceRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task <IEnumerable<Convenience>> GetAllAsync()
            => await _databaseContext.Conveniences.ToListAsync();

        public async Task<Convenience> GetAsync(Guid id)
            => await _databaseContext.Conveniences.SingleOrDefaultAsync(x => x.Id == id);
        
        public async Task UpdateAsync(Convenience convenience)
        {
            _databaseContext.Update(convenience);
            await Task.CompletedTask;
        }
    }
}