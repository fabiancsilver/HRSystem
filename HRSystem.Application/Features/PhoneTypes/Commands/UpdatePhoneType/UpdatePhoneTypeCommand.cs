using MediatR;

namespace HRSystem.Application.Features.PhoneTypes.Commands.UpdatePhoneType
{
    public class UpdatePhoneTypeCommand : IRequest<UpdatePhoneTypeCommandResponse>
    {
        public int PhoneTypeID { get; set; }
        public string Name { get; set; }
    }
}
