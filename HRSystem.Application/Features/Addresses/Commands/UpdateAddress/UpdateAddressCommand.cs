using MediatR;

namespace HRSystem.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<UpdateAddressCommandResponse>
    {
        public int AddressID { get; set; }

        public int EmployeeID { get; set; }

        public int AddressTypeID { get; set; }

        public string Line1 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}
