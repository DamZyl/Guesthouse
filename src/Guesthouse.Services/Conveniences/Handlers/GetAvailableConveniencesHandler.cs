using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Conveniences.Dto;
using Guesthouse.Services.Conveniences.Queries;

namespace Guesthouse.Services.Conveniences.Handlers
{
    public class GetAvailableConveniencesHandler : IQueryHandler<GetAvailableConveniences, IEnumerable<ConvenienceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetAvailableConveniencesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ConvenienceDto>> HandleAsync(GetAvailableConveniences query)
        {
            var conveniences = await _unitOfWork.ConvenienceRepository.GetAvailableAsync();

            return _mapper.Map<IEnumerable<ConvenienceDto>>(conveniences);
        }
    }
}