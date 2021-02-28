using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Shifts.Commands.CreateShift
{
    public class CreateShiftCommandResponse : BaseResponse
    {
        public CreateShiftCommandResponse() : base()
        {

        }

        public CreateShiftDto Shift { get; set; }
    }
}