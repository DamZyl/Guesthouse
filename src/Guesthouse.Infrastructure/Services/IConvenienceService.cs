using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Infrastructure.DTO;

namespace Guesthouse.Infrastructure.Services
{
    public interface IConvenienceService
    {
        Task<IEnumerable<Convenience>> GetAllAsync();
    }
}