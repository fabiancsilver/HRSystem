using HRSystem.Application.Features.Phones.Commands.CreatePhone;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Phones.Queries.GetPhoneByEmployee
{
    public class GetPhonesByEmployeeQuery : IRequest<GetPhonesByEmployeeQueryResponse>
    {
        public int EmployeeID { get; set; }
    }
}
