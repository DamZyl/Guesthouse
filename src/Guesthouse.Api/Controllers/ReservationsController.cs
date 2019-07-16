using System;
using System.Threading.Tasks;
using Guesthouse.Infrastructure.Commands.Reservation;
using Guesthouse.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    public class ReservationsController : ApiBaseController
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomService _roomService;

        public ReservationsController(IReservationService reservationService,
                IRoomService roomService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resevations = await _reservationService.GetAllAsync();

            return Json(resevations);
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetForClient(Guid clientId)
        {
            var resevationsForClient = await _reservationService.GetForClient(clientId);

            return Json(resevationsForClient);
        }

        [HttpGet("{reservationId}")]
        public async Task<IActionResult> Get(Guid reservationId)
        {
            var resevation = await _reservationService.GetAsync(reservationId);

            return Json(resevation);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReservation command)
        {
            command.Id = Guid.NewGuid();
            Guid clientId = new Guid("9a3f404f-b234-4aac-98ec-eb8357d36b28"); // Test delete later!!!

            await _reservationService.CreateAsync(clientId, command.Id, command.Description,
                    command.StartReservation, command.EndReservation);

            var rooms = await _roomService.GetAvailableAsync(); // Test delete later!!!

            await _reservationService.ReservationPlaceAsync(clientId, command.Id, rooms);

            return Created($"/reservations/{command.Id}", null);
        }

        [HttpPut("{reservationId}")]
        public async Task<IActionResult> Put(Guid reservationId, [FromBody] UpdateReservation command)
        {
            await _reservationService.UpdateAsync(reservationId, command.Description);

            return NoContent();
        }

        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> Delete(Guid reservationId)
        {
            Guid clientId = new Guid("9a3f404f-b234-4aac-98ec-eb8357d36b28"); // Test delete later!!!

            await _reservationService.DeleteAsync(reservationId);

            var rooms = await _roomService.GetForReservationAsync(reservationId);
            await _reservationService.CancelReservationPlaceAsync(clientId, reservationId, rooms);

            return NoContent();
        }
    }
}