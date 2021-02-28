using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.AddressTypes.Queries.GetAddressTypes
{
    public class GetAddressTypesQueryHandler : IRequestHandler<GetAddressTypesQuery, IEnumerable<GetAddressTypesVm>>
    {
        private readonly IHRAsyncRepository<AddressType> _addressTypeRepository;

        private readonly IMapper _mapper;

        public GetAddressTypesQueryHandler(IMapper mapper, IHRAsyncRepository<AddressType> addressTypeRepository)
        {
            _mapper = mapper;
            _addressTypeRepository = addressTypeRepository;
        }

        public async Task<IEnumerable<GetAddressTypesVm>> Handle(GetAddressTypesQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var addressTypes = await _addressTypeRepository.GetAll(queryParameters);
            var addressTypesVm = _mapper.Map<IEnumerable<GetAddressTypesVm>>(addressTypes);

            return addressTypesVm;
        }
    }
}
