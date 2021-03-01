using HRSystem.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.GetDepartments.Queries.GetDepartments
{
    public class GetDepartmentsQuery : IRequest<IEnumerable<GetDepartmentsVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
