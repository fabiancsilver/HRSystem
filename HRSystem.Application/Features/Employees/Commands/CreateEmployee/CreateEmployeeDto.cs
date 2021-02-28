using System;

namespace HRSystem.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeDto
    {
        public int EmployeeID { get; set; }

        public string Name { get; set; }

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
