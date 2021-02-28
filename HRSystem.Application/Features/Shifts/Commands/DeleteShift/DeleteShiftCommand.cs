using MediatR;

namespace HRSystem.Application.Features.Shifts.Commands.DeleteShift
{
    public class DeleteShiftCommand : IRequest<DeleteShiftCommandResponse>
    {
        public int ShiftID { get; set; }
    }
}
