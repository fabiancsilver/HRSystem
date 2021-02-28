using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.EmailTypes.Commands.CreateEmailType
{
    public class CreateEmailTypeCommandResponse : BaseResponse
    {
        public CreateEmailTypeCommandResponse() : base()
        {

        }

        public CreateEmailTypeDto EmailType { get; set; }
    }
}