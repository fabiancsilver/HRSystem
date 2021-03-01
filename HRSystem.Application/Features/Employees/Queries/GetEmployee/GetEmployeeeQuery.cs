using MediatR;

namespace HRSystem.Application.Features.Employees.Queries.GetEmployee
{
    public class GetEmployeeQuery : IRequest<GetEmployeeVm>
    {
        public int EmployeeID { get; set; }
    }
}
