using System;
using System.ComponentModel.DataAnnotations;

namespace HRSystem.Domain.HR
{
    public class LogEmployee
    {
        [Key]
        public int LogEmployeeID { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int PositionID { get; set; }

        public int DepartmentID { get; set; }

        public int StatusID { get; set; }

        public int ShiftID { get; set; }

        public int? ManagerID { get; set; }

        public string TeamMemberPhoto { get; set; }

        public int FavoriteColorID { get; set; }

        public int? PreferredPhoneID { get; set; }
    }
}
