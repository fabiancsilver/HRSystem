using HRSystem.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Statuses.Queries.GetStatuses
{
    public class GetStatusesQuery : IRequest<IEnumerable<GetStatusesVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
