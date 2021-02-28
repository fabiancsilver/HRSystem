using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandResponse : BaseResponse
    {
        public UpdateAddressCommandResponse() : base()
        {

        }

        public UpdateAddressDto Address { get; set; }
    }
}