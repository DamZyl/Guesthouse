using System.Threading.Tasks;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.Extensions;
using Guesthouse.Services.Invoices.Commands;
using Guesthouse.Services.Utils;


namespace Guesthouse.Services.Invoices.Handlers
{
    public class SendInvoiceHandler : ICommandHandler<SendInvoice>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SendInvoiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(SendInvoice command)
        {
            var invoice = await _unitOfWork.InvoiceRepository.GetOrFailAsync(command.Id);
            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(invoice.ClientId);

            //MailSender.Send("Reservation", "Hello", client.Email);
            MailSender.Send("Reservation", "Hello", invoice.PdfPath);
        }
    }
}