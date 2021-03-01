using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.EmailTypes.Queries.GetEmailTypes
{
    public class GetEmailTypesQueryHandler : IRequestHandler<GetEmailTypesQuery, IEnumerable<GetEmailTypesVm>>
    {
        private readonly IHRAsyncRepository<EmailType> _emailTypeRepository;

        private readonly IMapper _mapper;

        public GetEmailTypesQueryHandler(IMapper mapper, IHRAsyncRepository<EmailType> emailTypeRepository)
        {
            _mapper = mapper;
            _emailTypeRepository = emailTypeRepository;
        }

        public async Task<IEnumerable<GetEmailTypesVm>> Handle(GetEmailTypesQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var emailTypes = await _emailTypeRepository.GetAll(queryParameters);
            var emailTypesVm = _mapper.Map<IEnumerable<GetEmailTypesVm>>(emailTypes);

            return emailTypesVm;
        }
    }
}
