using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;

namespace Guesthouse.Core.Repositories
{
    public interface IConvenienceRepository : IRepository
    {
        Task<Convenience> GetAsync(Guid id);
        Task<IEnumerable<Convenience>> GetAllAsync();
        Task<IEnumerable<Convenience>> GetAvailableAsync();
        Task UpdateAsync(Convenience convenience);
    }
}