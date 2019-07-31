using System.Threading.Tasks;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Invoices.Commands;

namespace Guesthouse.Services.Invoices.Handlers
{
    public class CreateInvoiceHandler : ICommandHandler<CreateInvoice>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateInvoiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // Add logic!!!
        public async Task HandleAsync(CreateInvoice command)
        {
            /*var invoice = await _unitOfWork.InvoiceRepository.GetAsync(command.Id);
            invoice = Invoice.Create(command.Id, command.ClientId, command.EmployeeId, command.ReservationId, command.IssueDate, command.PayDate);
            
            await _unitOfWork.InvoiceRepository.AddAsync(invoice);
            await _unitOfWork.Complete();*/
        }
    }
}