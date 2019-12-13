using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Rooms.Dto;
using Guesthouse.Services.Rooms.Queries;

namespace Guesthouse.Services.Rooms.Handlers
{
    public class GetRoomsHandler : IQueryHandler<GetRooms, IEnumerable<RoomDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRoomsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<RoomDto>> HandleAsync(GetRooms query)
        {
            var rooms = await _unitOfWork.RoomRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }
    }
}