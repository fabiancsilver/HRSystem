using MediatR;

namespace HRSystem.Application.Features.AddressTypes.Commands.DeleteAddressType
{
    public class DeleteAddressTypeCommand : IRequest<DeleteAddressTypeCommandResponse>
    {
        public int AddressTypeID { get; set; }
    }
}
