using AutoMapper;
using Guesthouse.Core.Repositories;
using Guesthouse.Services.Invoices.Dto;
using Guesthouse.Services.Invoices.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guesthouse.Services.Invoices.Handlers
{
    public class GetInvoicesForClientHandler : IQueryHandler<GetInvoicesForClient, IEnumerable<InvoiceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInvoicesForClientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvoiceDto>> HandleAsync(GetInvoicesForClient query)
        {
            var invoices = await _unitOfWork.InvoiceRepository.GetInvoicesForClientAsync(query.ClientId);

            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }
    }
}

