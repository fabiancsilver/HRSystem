using MediatR;

namespace HRSystem.Application.Features.Phones.Commands.CreatePhone
{
    public class CreatePhoneCommand : IRequest<CreatePhoneCommandResponse>
    {

        public int PhoneID { get; set; }

        public int EmployeeID { get; set; }

        public int PhoneTypeID { get; set; }

        public string PhoneNumber { get; set; }

    }
}
