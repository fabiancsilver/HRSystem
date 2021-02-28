using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandResponse : BaseResponse
    {
        public DeleteDepartmentCommandResponse() : base()
        {

        }

        public DeleteDepartmentDto Department { get; set; }
    }
}