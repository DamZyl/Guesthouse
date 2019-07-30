using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Guesthouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiBaseController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public ApiBaseController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        protected ActionResult<T> Result<T>(T result)
        {
            if (result == null)
            {
                return NotFound();
            }

            return Json(result);
        }

        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) : Guid.Empty;
        
        protected async Task SendAsync<T>(T command) where T : ICommand
            => await _dispatcher.SendAsync(command);

        protected async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _dispatcher.QueryAsync(query);
    }    
}