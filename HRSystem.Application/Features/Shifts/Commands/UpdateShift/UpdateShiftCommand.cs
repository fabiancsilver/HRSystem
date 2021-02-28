using MediatR;

namespace HRSystem.Application.Features.Shifts.Commands.UpdateShift
{
    public class UpdateShiftCommand : IRequest<UpdateShiftCommandResponse>
    {
        public int ShiftID { get; set; }
        public string Name { get; set; }
    }
}
