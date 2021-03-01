using HRSystem.Domain.HR;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Domain.Infrastructure
{
    public class PermissionEmployee
    {
        [ForeignKey("Permission")]
        public int PermissionID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public Permission Permission { get; set; }

        public Employee Employee { get; set; }
    }
}
