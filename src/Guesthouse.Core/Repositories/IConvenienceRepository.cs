using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;

namespace Guesthouse.Core.Repositories
{
    public interface IConvenienceRepository
    {
        Task<IEnumerable<Convenience>> GetAllAsync();
    }
}