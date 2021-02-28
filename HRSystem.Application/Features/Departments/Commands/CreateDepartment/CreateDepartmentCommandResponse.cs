using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandResponse : BaseResponse
    {
        public CreateDepartmentCommandResponse() : base()
        {

        }

        public CreateDepartmentDto Department { get; set; }
    }
}