using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Statuses.Queries.GetStatus
{
    public class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, GetStatusVm>
    {
        private readonly IHRAsyncRepository<Status> _statusRepository;
        
        private readonly IMapper _mapper;

        public GetStatusQueryHandler(IMapper mapper, IHRAsyncRepository<Status> statusRepository)
        {
            _mapper = mapper;
            _statusRepository = statusRepository;            
        }

        public async Task<GetStatusVm> Handle(GetStatusQuery request, CancellationToken cancellationToken)
        {
            var status = await _statusRepository.GetById(request.StatusID);
            var statusVm = _mapper.Map<GetStatusVm>(status);            

            return statusVm;
        }
    }
}
