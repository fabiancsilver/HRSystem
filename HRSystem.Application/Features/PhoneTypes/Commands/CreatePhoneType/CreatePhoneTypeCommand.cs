using MediatR;

namespace HRSystem.Application.Features.PhoneTypes.Commands.CreatePhoneType
{
    public class CreatePhoneTypeCommand : IRequest<CreatePhoneTypeCommandResponse>
    {
        public string Name { get; set; }
    }
}
