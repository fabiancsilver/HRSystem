using HRSystem.Application.Features.Phones.Queries.GetPhoneByEmployee;
using HRSystem.Application.Responses;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Phones.Commands.CreatePhone
{
    public class GetPhonesByEmployeeQueryResponse : BaseResponse
    {
        public GetPhonesByEmployeeQueryResponse() : base()
        {

        }

        public ICollection<GetPhonesByEmployeeVm> Phones { get; set; }
    }
}