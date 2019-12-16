using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Services;
using Guesthouse.Services.Conveniences.Commands;
using Guesthouse.Services.Conveniences.Dto;
using Guesthouse.Services.Conveniences.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    [Authorize]
    public class ConveniencesController : ApiBaseController
    {
        public ConveniencesController(IDispatcher dispatcher) : base(dispatcher) { }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConvenienceDto>>> Get([FromQuery] GetConveniences query)
            => Result(await QueryAsync(query));
        
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<ConvenienceDto>>> GetAvailable([FromQuery] GetAvailableConveniences query)
            => Result(await QueryAsync(query));
        
        [HttpPut("{convenienceId}")]
        public async Task<ActionResult> Put(Guid convenienceId, [FromBody] UpdateConvenience command)
        {
            command.Id = convenienceId;

            await SendAsync(command);

            return NoContent();
        }
    }
}