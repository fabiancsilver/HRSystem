using MediatR;

namespace HRSystem.Application.Features.AddressTypes.Commands.UpdateAddressType
{
    public class UpdateAddressTypeCommand : IRequest<UpdateAddressTypeCommandResponse>
    {
        public int AddressTypeID { get; set; }
        public string Name { get; set; }
    }
}
