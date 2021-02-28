using AutoMapper;
using HRSystem.Application.Contracts.Persistence;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Application.Features.Addresses.Commands.CreateAddress;
using HRSystem.Application.Features.Addresses.Queries.GetByEmployee;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Addresses.Queries.GetAddressByEmployee
{
    public class GetAddressByEmployeeQueryHandler : IRequestHandler<GetAddressByEmployeeQuery, GetByEmployeeQueryResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressTypeRepository _addressTypeRepository;
        private readonly IMapper _mapper;

        public GetAddressByEmployeeQueryHandler(IMapper mapper,
                                                IAddressRepository addressRepository,
                                                IAddressTypeRepository addressTypeRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressTypeRepository = addressTypeRepository;
        }

        public async Task<GetByEmployeeQueryResponse> Handle(GetAddressByEmployeeQuery request, CancellationToken cancellationToken)
        {
            var response = new GetByEmployeeQueryResponse();
            var address = await _addressRepository.GetByEmployee(request.EmployeeID);
            var addressVm = _mapper.Map<GetAddressByEmployeeVm>(address);
            if (address == null)
            {
                response.Success = false;
                response.Address = null;
                return response;
            }

            var addressType = await _addressTypeRepository.GetById(addressVm.AddressTypeID);
            addressVm.AddressType = _mapper.Map<AddressTypeDto>(addressType);

            if (addressType == null)
            {
                response.Success = false;
                response.Address = null;
                return response;
            }

            response.Address = addressVm;
            return response;
        }
    }
}
