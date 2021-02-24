using HRSystem.Domain.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
