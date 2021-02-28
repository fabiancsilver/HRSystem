using HRSystem.Application.Common;
using HRSystem.Application.Features.GetDepartments.Queries.GetDepartments;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRSystem.Application.Features.GetDepartments.Queries.GetDepartments
{
    public class GetDepartmentsQuery : IRequest<IEnumerable<GetDepartmentsVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
