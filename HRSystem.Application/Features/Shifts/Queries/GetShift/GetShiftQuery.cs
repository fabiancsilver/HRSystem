using MediatR;

namespace HRSystem.Application.Features.Shifts.Queries.GetShift
{
    public class GetShiftQuery : IRequest<GetShiftVm>
    {
        public int ShiftID { get; set; }
    }
}
