using Guesthouse.Services;
using Guesthouse.Services.Invoices.Commands;
using Guesthouse.Services.Invoices.Dto;
using Guesthouse.Services.Invoices.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Api.Utils;
using Guesthouse.Core.Repositories;

namespace Guesthouse.Api.Controllers
{
    public class InvoicesController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoicesController(IDispatcher dispatcher, IUnitOfWork unitOfWork) : base(dispatcher)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> Get([FromQuery] GetInvoices query)
            => Result(await QueryAsync(query));

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetForClient(Guid clientId)
            => Result(await QueryAsync(new GetInvoicesForClient { ClientId = clientId }));

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<InvoiceDto>> Get(Guid invoiceId)
            => Result(await QueryAsync(new GetInvoice { Id = invoiceId }));

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateInvoice command)
        {
            command.EmployeeId = UserId;

            await SendAsync(command);

            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPost("send")]
        public async Task<ActionResult> Post([FromBody] SendInvoice command)
        {
            await PdfGenerator.Generate(command.Id, _unitOfWork);
            await SendAsync(command);

            return NoContent();
        }

        [HttpDelete("{invoiceId}")]
        public async Task<ActionResult> Delete(Guid invoiceId)
        {
            await SendAsync(new DeleteInvoice { Id = invoiceId });

            return NoContent();
        }
    }
}