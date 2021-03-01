using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Shifts.Queries.GetShift
{
    public class GetShiftQueryHandler : IRequestHandler<GetShiftQuery, GetShiftVm>
    {
        private readonly IHRAsyncRepository<Shift> _shiftRepository;

        private readonly IMapper _mapper;

        public GetShiftQueryHandler(IMapper mapper, IHRAsyncRepository<Shift> shiftRepository)
        {
            _mapper = mapper;
            _shiftRepository = shiftRepository;
        }

        public async Task<GetShiftVm> Handle(GetShiftQuery request, CancellationToken cancellationToken)
        {
            var shift = await _shiftRepository.GetById(request.ShiftID);
            var shiftVm = _mapper.Map<GetShiftVm>(shift);

            return shiftVm;
        }
    }
}
