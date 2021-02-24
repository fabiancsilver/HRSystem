using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Domain.Infrastructure
{
    public class Permission
    {
        public int PermissionID { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
    }
}
