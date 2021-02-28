using HRSystem.Application.Features.Infrastructure.PermissionEmployees.Queries.GetPermissionEmployees;
using System;

namespace HRSystem.Application.Features.Notifications.Queries.GetNotifications
{
    public class GetPermissionEmployeesVm
    {
        public int PermissionID { get; set; }

        public int EmployeeID { get; set; }    
        
        public GetPermissionEmployeesPermissionDto Permission { get; set; }

        public GetPermissionEmployeesEmployeeDto Employee { get; set; }
    }
}
