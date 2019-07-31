using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Invoices.Commands;

namespace Guesthouse.Services.Invoices.Handlers
{
    public class DeleteInvoiceHandler : ICommandHandler<DeleteInvoice>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInvoiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(DeleteInvoice command)
        {
            var invoice = await _unitOfWork.InvoiceRepository.GetOrFailAsync(command.Id);

            await _unitOfWork.InvoiceRepository.DeleteAsync(invoice);
            await _unitOfWork.Complete();
        }
    }
}