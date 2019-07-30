using System;
using System.Threading.Tasks;
using Guesthouse.Services;
using Guesthouse.Services.Services;
using Guesthouse.Services.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    public class EmployeesController : ApiBaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IDispatcher dispatcher, IEmployeeService employeeService) : base(dispatcher)
        {
            _employeeService = employeeService;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
            => Json(await _employeeService.GetAccountAsync(UserId)); 
        
        [HttpPost("register")]
        public async Task<ActionResult> Post([FromBody]Register command)
        {
            await _employeeService.RegisterAsync(Guid.NewGuid(), command.FirstName, command.LastName,
                command.Email, command.Password, command.EmployeeRole);

            return Created("/employees", null);
        }
        
        [HttpPost("login")]
        public async Task<ActionResult> Post([FromBody]Login command)
            => Json(await _employeeService.LoginAsync(command.Email, command.Password));
    }
}