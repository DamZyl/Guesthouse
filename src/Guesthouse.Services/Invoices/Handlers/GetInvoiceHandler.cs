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
    public class GetInvoiceHandler : IQueryHandler<GetInvoice, InvoiceDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInvoiceHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InvoiceDto> HandleAsync(GetInvoice query)
        {
            var invoice = await _unitOfWork.InvoiceRepository.GetAsync(query.Id);

            return _mapper.Map<InvoiceDto>(invoice);
        }
    }
}
