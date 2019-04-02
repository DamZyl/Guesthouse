using System;
using System.Threading.Tasks;
using Guesthouse.Core.Domain;

namespace Guesthouse.Core.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetAsync(Guid id);
    }
}