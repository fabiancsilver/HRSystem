using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Statuses.Commands.DeleteStatus
{
    public class DeleteStatusCommandResponse : BaseResponse
    {
        public DeleteStatusCommandResponse() : base()
        {

        }

        public DeleteStatusDto Status { get; set; }
    }
}