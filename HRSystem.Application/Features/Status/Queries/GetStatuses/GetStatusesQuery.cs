using HRSystem.Application.Common;
using HRSystem.Application.Features.Statuses.Queries.GetStatus;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Statuses.Queries.GetStatuses
{
    public class GetStatusesQuery : IRequest<IEnumerable<GetStatusesVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
