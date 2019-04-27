using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;
using Guesthouse.Infrastructure.DTO;

namespace Guesthouse.Infrastructure.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            var rooms = await _unitOfWork.RoomRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        // public async Task<IEnumerable<Room>> GetAvailableAsync()
        // {
        //     var availableRooms = await _unitOfWork.RoomRepository.GetAvailableAsync();

        //     return _mapper.Map<IEnumerable<RoomDto>>(availableRooms);
        // }

        public async Task<IEnumerable<Room>> GetAvailableAsync()
            => await _unitOfWork.RoomRepository.GetAvailableAsync();

        public async Task<IEnumerable<RoomDto>> GetOccupiedAsync()
        {
            var occupiedRooms = await _unitOfWork.RoomRepository.GetOccupiedAsync();

            return _mapper.Map<IEnumerable<RoomDto>>(occupiedRooms);
        }

        public async Task<IEnumerable<Room>> GetForReservationAsync(Guid id)
            => await _unitOfWork.RoomRepository.GetForReservationAsync(id);
    }
}