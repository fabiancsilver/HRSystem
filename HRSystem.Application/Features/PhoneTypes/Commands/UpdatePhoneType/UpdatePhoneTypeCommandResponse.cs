using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.PhoneTypes.Commands.UpdatePhoneType
{
    public class UpdatePhoneTypeCommandResponse : BaseResponse
    {
        public UpdatePhoneTypeCommandResponse() : base()
        {

        }

        public UpdatePhoneTypeDto PhoneType { get; set; }
    }
}