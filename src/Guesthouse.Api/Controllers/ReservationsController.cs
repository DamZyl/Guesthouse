using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guesthouse.Services;
using Guesthouse.Services.Reservations.Commands;
using Guesthouse.Services.Reservations.Dto;
using Guesthouse.Services.Reservations.Queries;
using Guesthouse.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    public class ReservationsController : ApiBaseController
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;
        private readonly IConvenienceService _convenienceService;

        public ReservationsController(IDispatcher dispatcher, IReservationService reservationService,
                IRoomService roomService, IConvenienceService convenienceService) : base(dispatcher)
        {
            _reservationService = reservationService;
            _roomService = roomService;
            _convenienceService = convenienceService;
        }

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

            return CreatedAtAction(nameof(Get), new {id = command.Id}, null);
        }

        [HttpPut("{reservationId}")]
        public async Task<ActionResult> Put(Guid reservationId, [FromBody] UpdateReservation command)
        {
            await _reservationService.UpdateAsync(reservationId, command.Description);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{reservationId}")]
        public async Task<ActionResult> Delete(Guid reservationId)
        {
            await _reservationService.DeleteAsync(reservationId);

            var rooms = await _roomService.GetForReservationAsync(reservationId);
            await _reservationService.CancelReservationPlaceAsync(UserId, reservationId, rooms);

            return NoContent();
        }
    }
}