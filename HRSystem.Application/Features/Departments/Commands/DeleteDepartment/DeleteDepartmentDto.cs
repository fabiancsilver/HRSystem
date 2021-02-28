using System;

namespace HRSystem.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentDto
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }
    }
}
