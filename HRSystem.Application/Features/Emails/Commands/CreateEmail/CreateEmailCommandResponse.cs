using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Emails.Commands.CreateEmail
{
    public class CreateEmailCommandResponse : BaseResponse
    {
        public CreateEmailCommandResponse() : base()
        {

        }

        public CreateEmailDto Email { get; set; }
    }
}