using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.PhoneTypes.Commands.DeletePhoneType
{
    public class DeletePhoneTypeCommandResponse : BaseResponse
    {
        public DeletePhoneTypeCommandResponse() : base()
        {

        }

        public DeletePhoneTypeDto PhoneType { get; set; }
    }
}