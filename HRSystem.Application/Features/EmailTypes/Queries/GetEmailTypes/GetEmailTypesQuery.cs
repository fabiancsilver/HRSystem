using HRSystem.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.EmailTypes.Queries.GetEmailTypes
{
    public class GetEmailTypesQuery : IRequest<IEnumerable<GetEmailTypesVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
