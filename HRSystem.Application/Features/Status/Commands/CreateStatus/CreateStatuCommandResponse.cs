using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Statuses.Commands.CreateStatus
{
    public class CreateStatusCommandResponse : BaseResponse
    {
        public CreateStatusCommandResponse() : base()
        {

        }

        public CreateStatusDto Status { get; set; }
    }
}