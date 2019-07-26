using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Guesthouse.Core.Domain;
using Guesthouse.Core.Repositories;

namespace Guesthouse.Services.Services
{
    public class ConvenienceService : IConvenienceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConvenienceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /*public async Task<IEnumerable<ConvenienceDto>> GetAllAsync()
        {
            var rooms = await _unitOfWork.ConvenienceRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ConvenienceDto>>(rooms);
        }*/

        public async Task<IEnumerable<Convenience>> GetAllAsync()
            => await _unitOfWork.ConvenienceRepository.GetAllAsync();
    }
}