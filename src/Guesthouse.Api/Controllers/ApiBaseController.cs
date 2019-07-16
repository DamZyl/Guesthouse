using System;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiBaseController : Controller
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) : Guid.Empty;
    }    
}