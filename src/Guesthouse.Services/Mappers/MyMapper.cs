using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Conveniences.Dto;
using Guesthouse.Services.Rooms.Dto;
using Guesthouse.Services.Reservations.Dto;

namespace Guesthouse.Services.Mappers
{
    public static class MyMapper
    {
        // refactor!!! -> Code ony my mapper delete automapper!!!!!
        public async static Task<ReservationDetailsDto> MapReservationToDetails(Reservation reservation,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            var rooms = await unitOfWork.RoomRepository.GetAllAsync();
            var conveniences = await unitOfWork.ConvenienceRepository.GetAllAsync();
            
            var idSetRoom = new HashSet<Guid>(reservation.Rooms.Select(x => x.RoomId));
            var resultRooms = rooms.Where(x => idSetRoom.Contains(x.Id)).ToList();
            
            var idSetConvenience = new HashSet<Guid>(reservation.Conveniences.Select(x => x.ConvenienceId));
            var resultConveniences = conveniences.Where(x => idSetConvenience.Contains(x.Id)).ToList();
            
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
                Rooms = mapper.Map<IEnumerable<RoomDto>>(resultRooms),
                Conveniences = mapper.Map<IEnumerable<ConvenienceDto>>(resultConveniences)
            };
            
            return reservationDetails;
        }
    }
}