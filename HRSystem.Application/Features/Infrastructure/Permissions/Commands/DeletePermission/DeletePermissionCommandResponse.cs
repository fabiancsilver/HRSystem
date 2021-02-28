using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommandResponse : BaseResponse
    {
        public DeletePermissionCommandResponse() : base()
        {

        }

        public DeletePermissionDto Permission { get; set; }
    }
}