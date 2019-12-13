using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Conveniences.Dto;
using Guesthouse.Services.Conveniences.Queries;

namespace Guesthouse.Services.Conveniences.Handlers
{
    public class GetConveniencesHandler : IQueryHandler<GetConveniences, IEnumerable<ConvenienceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetConveniencesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ConvenienceDto>> HandleAsync(GetConveniences query)
        {
            var rooms = await _unitOfWork.ConvenienceRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ConvenienceDto>>(rooms);
        }
    }
}