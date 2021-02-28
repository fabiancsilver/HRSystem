using MediatR;

namespace HRSystem.Application.Features.PhoneTypes.Commands.DeletePhoneType
{
    public class DeletePhoneTypeCommand : IRequest<DeletePhoneTypeCommandResponse>
    {
        public int PhoneTypeID { get; set; }
    }
}
