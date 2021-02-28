using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.EmailTypes.Queries.GetEmailType
{
    public class GetEmailTypeQueryHandler : IRequestHandler<GetEmailTypeQuery, GetEmailTypeVm>
    {
        private readonly IHRAsyncRepository<EmailType> _emailTypeRepository;
        
        private readonly IMapper _mapper;

        public GetEmailTypeQueryHandler(IMapper mapper, IHRAsyncRepository<EmailType> emailTypeRepository)
        {
            _mapper = mapper;
            _emailTypeRepository = emailTypeRepository;            
        }

        public async Task<GetEmailTypeVm> Handle(GetEmailTypeQuery request, CancellationToken cancellationToken)
        {
            var emailType = await _emailTypeRepository.GetById(request.EmailTypeID);
            var emailTypeVm = _mapper.Map<GetEmailTypeVm>(emailType);            

            return emailTypeVm;
        }
    }
}
