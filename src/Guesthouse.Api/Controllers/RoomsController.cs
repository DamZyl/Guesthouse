using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Services;
using Guesthouse.Services.Rooms.Commands;
using Guesthouse.Services.Rooms.Dto;
using Guesthouse.Services.Rooms.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    [Authorize]
    public class RoomsController : ApiBaseController
    {
        public RoomsController(IDispatcher dispatcher) : base(dispatcher) { }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> Get([FromQuery] GetRooms query)
            => Result(await QueryAsync(query));
        
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAvailable([FromQuery] GetAvailableRooms query)
            => Result(await QueryAsync(query));
        
        [HttpPut("{roomId}")]
        public async Task<ActionResult> Put(Guid roomId, [FromBody] UpdateRoom command)
        {
            command.Id = roomId;

            await SendAsync(command);

            return NoContent();
        }
    }
}