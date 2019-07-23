using System;
using System.Threading.Tasks;
using Guesthouse.Infrastructure.Commands.Users;
using Guesthouse.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    public class ClientsController : ApiBaseController
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
            => Json(await _clientService.GetAccountAsync(UserId)); 
        
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]Register command)
        {
            await _clientService.RegisterAsync(Guid.NewGuid(), command.FirstName, command.LastName,
                command.Email, command.Password, command.PhoneNumber, command.PayType);

            return Created("/employees", null);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
            => Json(await _clientService.LoginAsync(command.Email, command.Password));
    }
}