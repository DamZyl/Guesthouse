using AutoMapper;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Reservations.Dto;
using Guesthouse.Services.Reservations.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guesthouse.Services.Conveniences.Dto;
using Guesthouse.Services.Mappers;

namespace Guesthouse.Services.Reservations.Handlers
{
    public class GetReservationHandler : IQueryHandler<GetReservation, ReservationDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReservationHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReservationDetailsDto> HandleAsync(GetReservation query)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetAsync(query.Id);

           // return _mapper.Map<ReservationDetailsDto>(reservation);
           return  await MyMapper.MapReservationToDetails(reservation, _unitOfWork, _mapper);
        }
    }
}
