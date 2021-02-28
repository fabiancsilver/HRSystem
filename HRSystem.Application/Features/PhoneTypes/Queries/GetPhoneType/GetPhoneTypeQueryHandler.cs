using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.PhoneTypes.Queries.GetPhoneType
{
    public class GetPhoneTypeQueryHandler : IRequestHandler<GetPhoneTypeQuery, GetPhoneTypeVm>
    {
        private readonly IHRAsyncRepository<PhoneType> _phoneTypeRepository;
        
        private readonly IMapper _mapper;

        public GetPhoneTypeQueryHandler(IMapper mapper, IHRAsyncRepository<PhoneType> phoneTypeRepository)
        {
            _mapper = mapper;
            _phoneTypeRepository = phoneTypeRepository;            
        }

        public async Task<GetPhoneTypeVm> Handle(GetPhoneTypeQuery request, CancellationToken cancellationToken)
        {
            var phoneType = await _phoneTypeRepository.GetById(request.PhoneTypeID);
            var phoneTypeVm = _mapper.Map<GetPhoneTypeVm>(phoneType);            

            return phoneTypeVm;
        }
    }
}
