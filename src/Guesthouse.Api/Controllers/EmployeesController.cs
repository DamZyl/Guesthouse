using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Infrastructure.Auth;
using Guesthouse.Services;
using Guesthouse.Services.Reservations.Commands;
using Guesthouse.Services.Users.Commands;
using Guesthouse.Services.Users.Dto;
using Guesthouse.Services.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    public class EmployeesController : ApiBaseController
    {
        public EmployeesController(IDispatcher dispatcher) : base(dispatcher) { }

        [Authorize]
        [HttpGet("account")]
        public async Task<ActionResult<AccountDto>> Get()
            => Result(await QueryAsync(new GetEmployee { Id = UserId }));
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> Get([FromQuery] GetEmployees query)
            => Result(await QueryAsync(query));
        
        [HttpPost("register")]
        public async Task<ActionResult> Post([FromBody]RegisterEmployee command)
        {
            await SendAsync(command);

            //return Created("/employees", null);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Post([FromBody] Login command)
            => Result(await QueryAsync(new LoginEmployee {Command = command}));
        
        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> Delete(Guid employeeId)
        {
            await SendAsync(new DeleteEmployee { Id = employeeId });

            return NoContent();
        }
    }
}