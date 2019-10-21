using System.Threading.Tasks;
using Guesthouse.Infrastructure.Auth;
using Guesthouse.Services;
using Guesthouse.Services.Users.Commands;
using Guesthouse.Services.Users.Dto;
using Guesthouse.Services.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    public class ClientsController : ApiBaseController
    {
        public ClientsController(IDispatcher dispatcher) : base(dispatcher) { }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AccountDto>> Get()
            => Result(await QueryAsync(new GetClient { Id = UserId })); 
        
        [HttpPost("register")]
        public async Task<ActionResult> Post([FromBody]RegisterClient command)
        {
            await SendAsync(command);

            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Post([FromBody] Login command)
            => Result(await QueryAsync(new LoginClient { Command = command }));
    }
}