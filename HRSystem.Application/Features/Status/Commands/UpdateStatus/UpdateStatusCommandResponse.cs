using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommandResponse : BaseResponse
    {
        public UpdateStatusCommandResponse() : base()
        {

        }

        public UpdateStatusDto Status { get; set; }
    }
}