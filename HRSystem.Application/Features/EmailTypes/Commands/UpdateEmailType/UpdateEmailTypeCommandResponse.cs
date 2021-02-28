using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.EmailTypes.Commands.UpdateEmailType
{
    public class UpdateEmailTypeCommandResponse : BaseResponse
    {
        public UpdateEmailTypeCommandResponse() : base()
        {

        }

        public UpdateEmailTypeDto EmailType { get; set; }
    }
}