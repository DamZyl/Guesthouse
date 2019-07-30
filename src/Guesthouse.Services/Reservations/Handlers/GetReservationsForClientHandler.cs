using AutoMapper;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Reservations.Dto;
using Guesthouse.Services.Reservations.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guesthouse.Services.Reservations.Handlers
{
    public class GetReservationsForClientHandler : IQueryHandler<GetReservationsForClient, IEnumerable<ReservationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReservationsForClientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationDto>> HandleAsync(GetReservationsForClient query)
        {
            var reservationsForClient = await _unitOfWork.ReservationRepository.GetForClient(query.ClientId);

            return _mapper.Map<IEnumerable<ReservationDto>>(reservationsForClient);
        }
    }
}
