using System.Collections.Generic;
using System.Linq;
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
            => await _databaseContext.Conveniences.Where(x => x.Name == "Hot Water").ToListAsync();
    }
}