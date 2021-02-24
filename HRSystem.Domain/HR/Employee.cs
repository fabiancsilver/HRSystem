using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Domain.HR
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }


        public DateTime? EndDate { get; set; }

        [ForeignKey("Position")]
        public int PositionID { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [ForeignKey("Status")]
        public int StatusID { get; set; }

        [ForeignKey("Shift")]
        public int ShiftID { get; set; }

        public int? ManagerID { get; set; }

        public string TeamMemberPhoto { get; set; }

        [ForeignKey("Color")]
        public int FavoriteColorID { get; set; }

        [ForeignKey("PreferredPhone")]
        public int? PreferredPhoneID { get; set; }

        public Position Position { get; set; }

        public Department Department { get; set; }

        public Status Status { get; set; }

        public Shift Shift { get; set; }

        [ForeignKey("ManagerID")]
        public Employee Manager { get; set; }

        public Color FavoriteColor { get; set; }

        public Phone PreferredPhone { get; set; }
    }
}
