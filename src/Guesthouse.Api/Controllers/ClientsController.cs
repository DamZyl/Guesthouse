using System;
using System.Threading.Tasks;
using Guesthouse.Services;
using Guesthouse.Services.Services;
using Guesthouse.Services.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    public class ClientsController : ApiBaseController
    {
        private readonly IClientService _clientService;

        public ClientsController(IDispatcher dispatcher, IClientService clientService) : base(dispatcher)
        {
            _clientService = clientService;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
            => Json(await _clientService.GetAccountAsync(UserId)); 
        
        [HttpPost("register")]
        public async Task<ActionResult> Post([FromBody]Register command)
        {
            await _clientService.RegisterAsync(Guid.NewGuid(), command.FirstName, command.LastName,
                command.Email, command.Password, command.PhoneNumber, command.PayType);

            return Created("/employees", null);
        }
        
        [HttpPost("login")]
        public async Task<ActionResult> Post([FromBody]Login command)
            => Json(await _clientService.LoginAsync(command.Email, command.Password));
    }
}