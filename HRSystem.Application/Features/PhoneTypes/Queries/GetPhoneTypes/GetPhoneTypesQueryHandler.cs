using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.PhoneTypes.Queries.GetPhoneTypes
{
    public class GetPhoneTypesQueryHandler : IRequestHandler<GetPhoneTypesQuery, IEnumerable<GetPhoneTypesVm>>
    {
        private readonly IHRAsyncRepository<PhoneType> _phoneTypeRepository;

        private readonly IMapper _mapper;

        public GetPhoneTypesQueryHandler(IMapper mapper, IHRAsyncRepository<PhoneType> phoneTypeRepository)
        {
            _mapper = mapper;
            _phoneTypeRepository = phoneTypeRepository;
        }

        public async Task<IEnumerable<GetPhoneTypesVm>> Handle(GetPhoneTypesQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var phoneTypes = await _phoneTypeRepository.GetAll(queryParameters);
            var phoneTypesVm = _mapper.Map<IEnumerable<GetPhoneTypesVm>>(phoneTypes);

            return phoneTypesVm;
        }
    }
}
