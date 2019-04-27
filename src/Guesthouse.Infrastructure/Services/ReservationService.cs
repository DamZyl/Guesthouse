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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReservationDetailsDto> GetAsync(Guid id)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetAsync(id);

            return _mapper.Map<ReservationDetailsDto>(reservation);
        }

        public async Task<IEnumerable<ReservationDto>> GetAllAsync()
        {
            var reservations = await _unitOfWork.ReservationRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }

        public async Task<IEnumerable<ReservationDto>> GetForClient(Guid clientId)
        {
            var reservationsForClient = await _unitOfWork.ReservationRepository.GetForClient(clientId);

            return _mapper.Map<IEnumerable<ReservationDto>>(reservationsForClient);
        }

        public async Task CreateAsync(Guid clientId, Guid id, string description,
                DateTime startReservation, DateTime endReservation)
        {
            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(clientId);
            var reservation = await _unitOfWork.ReservationRepository.GetAsync(id);

            reservation = Reservation.Create(id, description, startReservation, endReservation);
            //reservation.ReservationPlace(client);

            await _unitOfWork.ReservationRepository.AddAsync(reservation); 
            await _unitOfWork.Complete();
        }

        public async Task UpdateAsync(Guid id, string description)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetOrFailAsync(id);

            reservation.SetDescription(description);

            await _unitOfWork.ReservationRepository.UpdateAsync(reservation);
            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(Guid id)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetOrFailAsync(id);

            await _unitOfWork.ReservationRepository.DeleteAsync(reservation);
            await _unitOfWork.Complete();  
        }

        public async Task ReservationPlaceAsync(Guid clientId, Guid id, IEnumerable<Room> rooms,
                IEnumerable<Convenience> conveniences)
        {
            throw new NotImplementedException();
        }

        public async Task ReservationPlaceAsync(Guid clientId, Guid id, IEnumerable<Room> rooms)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetOrFailAsync(id);
            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(clientId);

            reservation.ReservationPlace(client, rooms);
            await _unitOfWork.Complete();
        }

        public async Task CancelReservationPlaceAsync(Guid clientId, Guid id, IEnumerable<Room> rooms)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetOrFailAsync(id);
            var client = await _unitOfWork.ClientRepository.GetOrFailAsync(clientId);

            reservation.CancelReservationPlace(client, rooms);
            await _unitOfWork.Complete();
        }
    }
}