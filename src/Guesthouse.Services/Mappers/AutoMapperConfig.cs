using System.Linq;
using AutoMapper;
using Guesthouse.Core.Domain;
using Guesthouse.Services.Conveniences.Dto;
using Guesthouse.Services.Invoices.Dto;
using Guesthouse.Services.Reservations.Dto;
using Guesthouse.Services.Users.Dto;
using Guesthouse.Services.Rooms.Dto;

namespace Guesthouse.Services.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reservation, ReservationDto>()
                    .ForMember(x => x.ReservationStatus, 
                        m => m.MapFrom(p => p.ReservationStatus.ToString()))
                    .ForMember(x => x.PayStatus, 
                        m => m.MapFrom(p => p.PayStatus.ToString()))
                    .ForMember(x => x.RoomsCount, 
                        m => m.MapFrom(p => p.Rooms.Count()))
                    .ForMember(x => x.ConveniencesCount, 
                        m => m.MapFrom(p => p.Conveniences.Count()));
                cfg.CreateMap<Reservation, ReservationDetailsDto>();
                cfg.CreateMap<Client, AccountDto>()
                    .ForMember(x => x.Role, 
                        m => m.MapFrom(p => p.ClientRole));
                cfg.CreateMap<Employee, AccountDto>()
                    .ForMember(x => x.Role, 
                        m => m.MapFrom(p => p.EmployeeRole));
                cfg.CreateMap<Room, RoomDto>();
                cfg.CreateMap<Convenience, ConvenienceDto>();
                cfg.CreateMap<Invoice, InvoiceDto>();
            })
            .CreateMapper();
    }
}