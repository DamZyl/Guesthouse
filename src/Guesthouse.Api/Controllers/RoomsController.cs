using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Services;
using Guesthouse.Services.Rooms.Dto;
using Guesthouse.Services.Rooms.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    public class RoomsController : ApiBaseController
    {
        public RoomsController(IDispatcher dispatcher) : base(dispatcher) { }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> Get([FromQuery] GetRooms query)
            => Result(await QueryAsync(query));
    }
}