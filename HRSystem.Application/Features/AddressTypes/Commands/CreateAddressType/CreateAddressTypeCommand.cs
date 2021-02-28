using MediatR;

namespace HRSystem.Application.Features.AddressTypes.Commands.CreateAddressType
{
    public class CreateAddressTypeCommand : IRequest<CreateAddressTypeCommandResponse>
    {
        public string Name { get; set; }
    }
}
