using System;

namespace HRSystem.Application.Features.Employees.Queries.GetEmployees
{
    public class GetEmployeesVm
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

        public GetEmployeesPositionDto Position { get; set; }

        public GetEmployeesDepartmentDto Department { get; set; }

        public GetEmployeesStatusDto Status { get; set; }

        public GetEmployeesShiftDto Shift { get; set; }

        
        public GetEmployeesEmployeeDto Manager { get; set; }

        public GetEmployeesColorDto FavoriteColor { get; set; }

        public GetEmployeesPhoneDto PreferredPhone { get; set; }
    }
}
