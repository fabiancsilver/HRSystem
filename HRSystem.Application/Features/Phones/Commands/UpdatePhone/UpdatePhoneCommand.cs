using MediatR;

namespace HRSystem.Application.Features.Phones.Commands.UpdatePhone
{
    public class UpdatePhoneCommand : IRequest<UpdatePhoneCommandResponse>
    {
        public int PhoneID { get; set; }

        public int EmployeeID { get; set; }

        public int PhoneTypeID { get; set; }

        public string PhoneNumber { get; set; }
    }
}
