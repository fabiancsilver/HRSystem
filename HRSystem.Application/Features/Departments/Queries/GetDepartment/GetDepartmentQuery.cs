using MediatR;
using System;

namespace HRSystem.Application.Features.Departments.Queries.GetDepartment
{
    public class GetDepartmentQuery : IRequest<GetDepartmentVm>
    {
        public int DepartmentID { get; set; }
    }
}
