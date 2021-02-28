using HRSystem.Application.Features.Addresses.Queries.GetAddressByEmployee;
using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Addresses.Commands.CreateAddress
{
    public class GetByEmployeeQueryResponse : BaseResponse
    {
        public GetByEmployeeQueryResponse() : base()
        {

        }

        public GetAddressByEmployeeVm Address { get; set; }
    }
}