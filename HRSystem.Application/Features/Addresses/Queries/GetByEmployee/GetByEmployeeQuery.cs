using HRSystem.Application.Features.Addresses.Commands.CreateAddress;
using MediatR;

namespace HRSystem.Application.Features.Addresses.Queries.GetAddressByEmployee
{
    public class GetAddressByEmployeeQuery : IRequest<GetByEmployeeQueryResponse>
    {
        public int EmployeeID { get; set; }
    }
}
