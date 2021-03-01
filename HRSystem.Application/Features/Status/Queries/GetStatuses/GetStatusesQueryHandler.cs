using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Statuses.Queries.GetStatuses
{
    public class GetStatusesQueryHandler : IRequestHandler<GetStatusesQuery, IEnumerable<GetStatusesVm>>
    {
        private readonly IHRAsyncRepository<Status> _statusRepository;

        private readonly IMapper _mapper;

        public GetStatusesQueryHandler(IMapper mapper, IHRAsyncRepository<Status> statusRepository)
        {
            _mapper = mapper;
            _statusRepository = statusRepository;
        }

        public async Task<IEnumerable<GetStatusesVm>> Handle(GetStatusesQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var statuses = await _statusRepository.GetAll(queryParameters);
            var statusesVm = _mapper.Map<IEnumerable<GetStatusesVm>>(statuses);

            return statusesVm;
        }
    }
}
