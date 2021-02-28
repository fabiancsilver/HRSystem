using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.AddressTypes.Commands.DeleteAddressType
{
    public class DeleteAddressTypeCommandResponse : BaseResponse
    {
        public DeleteAddressTypeCommandResponse() : base()
        {

        }

        public DeleteAddressTypeDto AddressType { get; set; }
    }
}