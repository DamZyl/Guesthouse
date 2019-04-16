using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.DTO;
using Guesthouse.Infrastructure.Extensions;

namespace Guesthouse.Infrastructure.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository,
                IClientRepository clientRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ReservationDetailsDto> GetAsync(Guid id)
        {
            var reservation = await _reservationRepository.GetAsync(id);

            return _mapper.Map<ReservationDetailsDto>(reservation);
        }

        public async Task<IEnumerable<ReservationDto>> GetAllAsync()
        {
            var reservations = await _reservationRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }

        public async Task<IEnumerable<ReservationDto>> GetForClient(Guid clientId)
        {
            var reservationsForClient = await _reservationRepository.GetForClient(clientId);

            return _mapper.Map<IEnumerable<ReservationDto>>(reservationsForClient);
        }

        public async Task CreateAsync(Guid clientId, Guid id, string description,
                DateTime startReservation, DateTime endReservation)
        {
            var client = await _clientRepository.GetOrFailAsync(clientId);
            var reservation = await _reservationRepository.GetAsync(id);

            reservation = Reservation.Create(id, description, startReservation, endReservation);
            reservation.ReservationPlace(client);

            await _reservationRepository.AddAsync(reservation); 
        }

        public async Task UpdateAsync(Guid id, string description)
        {
            var reservation = await _reservationRepository.GetOrFailAsync(id);

            reservation.SetDescription(description);

            await _reservationRepository.UpdateAsync(reservation);
        }

        public async Task DeleteAsync(Guid id)
        {
            var reservation = await _reservationRepository.GetOrFailAsync(id);

            await _reservationRepository.DeleteAsync(reservation);  
        }
    }
}