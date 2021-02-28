using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Phones.Commands.CreatePhone
{
    public class CreatePhoneCommandResponse : BaseResponse
    {
        public CreatePhoneCommandResponse() : base()
        {

        }

        public CreatePhoneDto Phone { get; set; }
    }
}