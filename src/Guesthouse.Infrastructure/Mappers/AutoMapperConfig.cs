using System.Linq;
using AutoMapper;
using Guesthouse.Core.Domain;
using Guesthouse.Infrastructure.DTO;

namespace Guesthouse.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                
                cfg.CreateMap<Reservation, ReservationDto>()
                    .ForMember(x => x.RoomsCount, m => m.MapFrom(p => p.Rooms.Count()));
                cfg.CreateMap<Reservation, ReservationDetailsDto>();
                cfg.CreateMap<Room, RoomDto>();
            })
            .CreateMapper();
    }
}