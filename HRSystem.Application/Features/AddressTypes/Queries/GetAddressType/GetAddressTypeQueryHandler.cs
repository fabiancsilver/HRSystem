using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.AddressTypes.Queries.GetAddressType
{
    public class GetAddressTypeQueryHandler : IRequestHandler<GetAddressTypeQuery, GetAddressTypeVm>
    {
        private readonly IHRAsyncRepository<Domain.HR.AddressType> _addressTypeRepository;

        private readonly IMapper _mapper;

        public GetAddressTypeQueryHandler(IMapper mapper, IHRAsyncRepository<Domain.HR.AddressType> addressTypeRepository)
        {
            _mapper = mapper;
            _addressTypeRepository = addressTypeRepository;
        }

        public async Task<GetAddressTypeVm> Handle(GetAddressTypeQuery request, CancellationToken cancellationToken)
        {
            var addressType = await _addressTypeRepository.GetById(request.AddressTypeID);
            var addressTypeVm = _mapper.Map<GetAddressTypeVm>(addressType);

            return addressTypeVm;
        }
    }
}
