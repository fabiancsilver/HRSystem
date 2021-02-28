using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Phones.Commands.UpdatePhone
{
    public class UpdatePhoneCommandResponse : BaseResponse
    {
        public UpdatePhoneCommandResponse() : base()
        {

        }

        public UpdatePhoneDto Phone { get; set; }
    }
}