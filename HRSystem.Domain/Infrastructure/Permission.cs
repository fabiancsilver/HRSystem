using System.ComponentModel.DataAnnotations;

namespace HRSystem.Domain.Infrastructure
{
    public class Permission
    {
        public int PermissionID { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
    }
}
