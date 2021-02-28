using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandResponse : BaseResponse
    {
        public UpdateDepartmentCommandResponse() : base()
        {

        }

        public UpdateDepartmentDto Department { get; set; }
    }
}