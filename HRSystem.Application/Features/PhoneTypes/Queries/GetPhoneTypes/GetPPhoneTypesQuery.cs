using HRSystem.Application.Common;
using HRSystem.Application.Features.PhoneTypes.Queries.GetPhoneType;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRSystem.Application.Features.PhoneTypes.Queries.GetPhoneTypes
{
    public class GetPhoneTypesQuery : IRequest<IEnumerable<GetPhoneTypesVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
