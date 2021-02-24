using HRSystem.Domain.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Domain.Infrastructure
{
    public class NotificationEmployee
    {
        [ForeignKey("Notification")]
        public int NotificationID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }        

        public Notification Notification { get; set; }

        public Employee Employee { get; set; }
    }
}
