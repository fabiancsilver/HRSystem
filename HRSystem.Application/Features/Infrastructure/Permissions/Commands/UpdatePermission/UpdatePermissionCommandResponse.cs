using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommandResponse : BaseResponse
    {
        public UpdatePermissionCommandResponse() : base()
        {

        }

        public UpdatePermissionDto Permission { get; set; }
    }
}