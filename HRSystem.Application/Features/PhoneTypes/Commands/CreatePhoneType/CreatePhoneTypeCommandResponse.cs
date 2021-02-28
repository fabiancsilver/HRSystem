using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.PhoneTypes.Commands.CreatePhoneType
{
    public class CreatePhoneTypeCommandResponse : BaseResponse
    {
        public CreatePhoneTypeCommandResponse() : base()
        {

        }

        public CreatePhoneTypeDto PhoneType { get; set; }
    }
}