using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.AddressTypes.Commands.CreateAddressType
{
    public class CreateAddressTypeCommandResponse : BaseResponse
    {
        public CreateAddressTypeCommandResponse() : base()
        {

        }

        public CreateAddressTypeDto AddressType { get; set; }
    }
}