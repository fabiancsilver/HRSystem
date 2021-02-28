using MediatR;

namespace HRSystem.Application.Features.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommand : IRequest<DeletePermissionCommandResponse>
    {
        public int PermissionID { get; set; }
    }
}
