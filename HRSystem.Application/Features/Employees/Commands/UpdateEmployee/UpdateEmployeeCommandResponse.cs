using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandResponse : BaseResponse
    {
        public UpdateEmployeeCommandResponse() : base()
        {

        }

        public UpdateEmployeeDto Employee { get; set; }
    }
}