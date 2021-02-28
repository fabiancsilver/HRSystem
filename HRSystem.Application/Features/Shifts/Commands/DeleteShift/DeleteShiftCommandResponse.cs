using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Shifts.Commands.DeleteShift
{
    public class DeleteShiftCommandResponse : BaseResponse
    {
        public DeleteShiftCommandResponse() : base()
        {

        }

        public DeleteShiftDto Shift { get; set; }
    }
}