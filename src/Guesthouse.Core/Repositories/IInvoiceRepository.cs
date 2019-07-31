using Guesthouse.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Guesthouse.Core.Repositories
{
    public interface IInvoiceRepository : IRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<IEnumerable<Invoice>> GetInvoicesForClientAsync(Guid clientId);
        Task<Invoice> GetAsync(Guid id);
        Task AddAsync(Invoice invoice);
        Task DeleteAsync(Invoice invoice);
    }
}