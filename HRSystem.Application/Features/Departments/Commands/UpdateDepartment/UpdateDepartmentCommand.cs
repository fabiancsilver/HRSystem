using MediatR;

namespace HRSystem.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<UpdateDepartmentCommandResponse>
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
    }
}
