using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Emails.Commands.UpdateEmail
{
    public class UpdateEmailCommandResponse : BaseResponse
    {
        public UpdateEmailCommandResponse() : base()
        {

        }

        public UpdateEmailDto Email { get; set; }
    }
}