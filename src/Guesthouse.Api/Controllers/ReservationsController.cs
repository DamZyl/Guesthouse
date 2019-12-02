using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Services;
using Guesthouse.Services.Reservations.Commands;
using Guesthouse.Services.Reservations.Dto;
using Guesthouse.Services.Reservations.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    public class ReservationsController : ApiBaseController
    {
        public ReservationsController(IDispatcher dispatcher) : base(dispatcher) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> Get([FromQuery] GetReservations query)
            => Result(await QueryAsync(query));

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetForClient(Guid clientId)
            => Result(await QueryAsync(new GetReservationsForClient { ClientId = clientId }));

        [HttpGet("{reservationId}")]
        public async Task<ActionResult<ReservationDetailsDto>> Get(Guid reservationId)
            => Result(await QueryAsync(new GetReservation { Id = reservationId }));

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateReservation command)
        {
            command.UserId = UserId;

            await SendAsync(command);

            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPut("{reservationId}")]
        public async Task<ActionResult> Put(Guid reservationId, [FromBody] UpdateReservation command)
        {
            command.Id = reservationId;

            await SendAsync(command);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{reservationId}")]
        public async Task<ActionResult> Delete(Guid reservationId)
        {
            await SendAsync(new DeleteReservation { Id = reservationId, UserId = UserId });

            return NoContent();
        }
    }
}