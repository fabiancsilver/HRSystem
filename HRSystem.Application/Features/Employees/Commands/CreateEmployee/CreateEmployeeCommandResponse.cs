using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandResponse : BaseResponse
    {
        public CreateEmployeeCommandResponse() : base()
        {

        }

        public CreateEmployeeDto Employee { get; set; }
    }
}