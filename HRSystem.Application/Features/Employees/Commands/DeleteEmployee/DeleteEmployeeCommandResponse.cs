using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandResponse : BaseResponse
    {
        public DeleteEmployeeCommandResponse() : base()
        {

        }

        public DeleteEmployeeDto Employee { get; set; }
    }
}