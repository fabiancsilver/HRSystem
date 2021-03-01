using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Notifications.Queries.GetNotifications
{
    public class GetPermissionEmployeesQuery : IRequest<IEnumerable<GetPermissionEmployeesVm>>
    {
        public int EmployeeID { get; set; }
    }
}
