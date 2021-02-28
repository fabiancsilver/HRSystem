using HRSystem.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQuery : IRequest<IEnumerable<GetPositionsVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
