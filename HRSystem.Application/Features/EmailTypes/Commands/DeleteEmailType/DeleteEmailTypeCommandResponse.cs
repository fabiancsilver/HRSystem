using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.EmailTypes.Commands.DeleteEmailType
{
    public class DeleteEmailTypeCommandResponse : BaseResponse
    {
        public DeleteEmailTypeCommandResponse() : base()
        {

        }

        public DeleteEmailTypeDto EmailType { get; set; }
    }
}