using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommandResponse : BaseResponse
    {
        public CreatePermissionCommandResponse() : base()
        {

        }

        public CreatePermissionDto Permission { get; set; }
    }
}