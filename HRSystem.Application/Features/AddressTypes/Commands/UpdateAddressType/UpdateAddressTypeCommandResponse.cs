using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.AddressTypes.Commands.UpdateAddressType
{
    public class UpdateAddressTypeCommandResponse : BaseResponse
    {
        public UpdateAddressTypeCommandResponse() : base()
        {

        }

        public UpdateAddressTypeDto AddressType { get; set; }
    }
}