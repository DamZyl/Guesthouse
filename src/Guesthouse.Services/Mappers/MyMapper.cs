using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.DTO;
using Guesthouse.Services.Reservations.Dto;

namespace Guesthouse.Services.Mappers
{
    public static class MyMapper
    {
        // refactor!!! -> Code ony my mapper delete automapper!!!!!
        public async static Task<ReservationDetailsDto> MapReservationToDetails(Reservation reservation,
            IRoomRepository roomRepository, IMapper mapper)
        {
            var rooms = await roomRepository.GetAllAsync();
            
            var idSet = new HashSet<Guid>(reservation.Rooms.Select(x => x.RoomId));
            var result = rooms.Where(x => idSet.Contains(x.Id)).ToList();
            
            var reservationDetails = new ReservationDetailsDto
            {
                Id = reservation.Id,
                Description = reservation.Description,
                ClientId = reservation.ClientId,
                ClientName =reservation.ClientName,
                Price = reservation.Price,
                StartReservation = reservation.StartReservation,
                EndReservation = reservation.EndReservation,
                ReservationStatus  = reservation.ReservationStatus.ToString(),
                PayStatus = reservation.PayStatus.ToString(),
                Message = reservation.Message,
                RoomsCount = reservation.Rooms.Count(),
                ConveniencesCount = reservation.Conveniences.Count(),
                Rooms = mapper.Map<IEnumerable<RoomDto>>(result),
                Conveniences = null
            };
            
            return reservationDetails;
        }
    }
}