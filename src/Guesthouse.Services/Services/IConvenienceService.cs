using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;

namespace Guesthouse.Services.Services
{
    public interface IConvenienceService
    {
        Task<IEnumerable<Convenience>> GetAllAsync();
    }
}