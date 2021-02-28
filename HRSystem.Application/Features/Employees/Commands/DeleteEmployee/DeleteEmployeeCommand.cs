using MediatR;

namespace HRSystem.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<DeleteEmployeeCommandResponse>
    {
        public int EmployeeID { get; set; }
    }
}
