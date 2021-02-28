using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Shifts.Commands.UpdateShift
{
    public class UpdateShiftCommandResponse : BaseResponse
    {
        public UpdateShiftCommandResponse() : base()
        {

        }

        public UpdateShiftDto Shift { get; set; }
    }
}