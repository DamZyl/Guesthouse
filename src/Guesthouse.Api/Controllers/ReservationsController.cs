using System;
using System.Threading.Tasks;
using Guesthouse.Infrastructure.Commands.Reservation;
using Guesthouse.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Guesthouse.Api.Controllers
{
    [Route("[controller]")]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
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
            Guid clientId = new Guid("9a3f404f-b234-4aac-98ec-eb8357d36b28"); // Test usunac to potem!!!

            await _reservationService.CreateAsync(clientId, command.Id, command.Description,
                    command.StartReservation, command.EndReservation);

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
            await _reservationService.DeleteAsync(reservationId);

            return NoContent();
        }
    }
}