using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, IEnumerable<GetPositionsVm>>
    {
        private readonly IHRAsyncRepository<Position> _positionRepository;

        private readonly IMapper _mapper;

        public GetPositionsQueryHandler(IMapper mapper, IHRAsyncRepository<Position> positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<IEnumerable<GetPositionsVm>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var positions = await _positionRepository.GetAll(queryParameters);
            var positionsVm = _mapper.Map<IEnumerable<GetPositionsVm>>(positions);

            return positionsVm;
        }
    }
}
