using MediatR;

namespace HRSystem.Application.Features.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommand : IRequest<CreatePermissionCommandResponse>
    {
        public string Name { get; set; }
    }
}
