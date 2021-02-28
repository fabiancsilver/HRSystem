using HRSystem.Application.Common;
using HRSystem.Application.Features.EmailTypes.Queries.GetEmailType;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRSystem.Application.Features.EmailTypes.Queries.GetEmailTypes
{
    public class GetEmailTypesQuery : IRequest<IEnumerable<GetEmailTypesVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
