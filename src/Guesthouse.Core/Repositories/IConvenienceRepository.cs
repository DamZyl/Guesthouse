using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;

namespace Guesthouse.Core.Repositories
{
    public interface IConvenienceRepository : IRepository
    {
        Task<IEnumerable<Convenience>> GetAllAsync();
    }
}