using HRSystem.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Permissions.Queries.GetPermissions
{
    public class GetPermissionsQuery : IRequest<IEnumerable<GetPermissionsVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
