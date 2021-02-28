using MediatR;

namespace HRSystem.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<DeleteDepartmentCommandResponse>
    {
        public int DepartmentID { get; set; }
    }
}
