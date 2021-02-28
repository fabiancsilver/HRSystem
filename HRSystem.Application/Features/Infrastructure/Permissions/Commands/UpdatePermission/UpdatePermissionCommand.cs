using MediatR;

namespace HRSystem.Application.Features.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommand : IRequest<UpdatePermissionCommandResponse>
    {
        public int PermissionID { get; set; }
        public string Name { get; set; }
    }
}
