using MediatR;

namespace HRSystem.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<CreateDepartmentCommandResponse>
    {
        public string Name { get; set; }
    }
}
