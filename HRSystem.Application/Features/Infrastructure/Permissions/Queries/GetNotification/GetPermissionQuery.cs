using MediatR;
using System;

namespace HRSystem.Application.Features.Permissions.Queries.GetPermission
{
    public class GetPermissionQuery : IRequest<GetPermissionVm>
    {
        public int PermissionID { get; set; }
    }
}
