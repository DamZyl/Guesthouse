using Guesthouse.Services;
using Guesthouse.Services.Invoices.Commands;
using Guesthouse.Services.Invoices.Dto;
using Guesthouse.Services.Invoices.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Guesthouse.Api.Controllers
{
    public class InvoicesController : ApiBaseController
    {
        public InvoicesController(IDispatcher dispatcher) : base(dispatcher) { }

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
            //command.UserId = UserId;

            await SendAsync(command);

            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpDelete("{invoiceId}")]
        public async Task<ActionResult> Delete(Guid invoiceId)
        {
            await SendAsync(new DeleteInvoice { Id = invoiceId });

            return NoContent();
        }
    }
}