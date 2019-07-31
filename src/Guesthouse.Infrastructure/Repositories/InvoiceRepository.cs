using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guesthouse.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DatabaseContext _databaseContext;

        public InvoiceRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Invoice> GetAsync(Guid id)
            => await _databaseContext.Invoices.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Invoice>> GetAllAsync()
            => await _databaseContext.Invoices.ToListAsync();

        public async Task<IEnumerable<Invoice>> GetInvoicesForClientAsync(Guid clientId)
            => await _databaseContext.Invoices.Where(x => x.ClientId == clientId).ToListAsync();

        public async Task AddAsync(Invoice invoice)
            => await _databaseContext.Invoices.AddAsync(invoice);

        public async Task DeleteAsync(Invoice invoice)
            => _databaseContext.Invoices.Remove(invoice);

    }
}
