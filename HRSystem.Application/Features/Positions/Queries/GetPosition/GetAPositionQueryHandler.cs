using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQueryHandler : IRequestHandler<GetPositionQuery, GetPositionVm>
    {
        private readonly IHRAsyncRepository<Domain.HR.Position> _positionRepository;

        private readonly IMapper _mapper;

        public GetPositionQueryHandler(IMapper mapper, IHRAsyncRepository<Domain.HR.Position> positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<GetPositionVm> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            var position = await _positionRepository.GetById(request.PositionID);
            var positionVm = _mapper.Map<GetPositionVm>(position);

            return positionVm;
        }
    }
}
