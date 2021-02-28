using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Application.Features.Shifts.Queries.GetShift;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Shifts.Queries.GetShifts
{
    public class GetShiftsQueryHandler : IRequestHandler<GetShiftsQuery, IEnumerable<GetShiftsVm>>
    {
        private readonly IHRAsyncRepository<Shift> _shiftRepository;

        private readonly IMapper _mapper;

        public GetShiftsQueryHandler(IMapper mapper, IHRAsyncRepository<Shift> shiftRepository)
        {
            _mapper = mapper;
            _shiftRepository = shiftRepository;
        }

        public async Task<IEnumerable<GetShiftsVm>> Handle(GetShiftsQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var shifts = await _shiftRepository.GetAll(queryParameters);
            var shiftsVm = _mapper.Map<IEnumerable<GetShiftsVm>>(shifts);

            return shiftsVm;
        }
    }
}
