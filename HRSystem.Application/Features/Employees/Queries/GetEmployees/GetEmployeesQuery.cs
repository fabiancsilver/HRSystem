using HRSystem.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Employees.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<IEnumerable<GetEmployeesVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
