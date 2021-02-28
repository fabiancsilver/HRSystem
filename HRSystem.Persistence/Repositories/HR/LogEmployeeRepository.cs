using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using HRSystem.Persistence.HR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.Persistence.Repositories.HR
{
    public class LogEmployeeRepository : HRRepository<LogEmployee>, ILogEmployeeRepository
    {
                
        public LogEmployeeRepository(HRContext context) : base(context)
        {
            
        }          

        public async Task<int> Log(Employee employee)
        {
            var logEmployee = new LogEmployee();
            logEmployee.LogEmployeeID = 0;
            logEmployee.EmployeeID = employee.EmployeeID;
            logEmployee.Name = employee.Name;
            logEmployee.StartDate = employee.StartDate;
            logEmployee.EndDate = employee.EndDate;
            logEmployee.PositionID = employee.PositionID;
            logEmployee.DepartmentID = employee.DepartmentID;
            logEmployee.StatusID = employee.StatusID;
            logEmployee.ShiftID = employee.ShiftID;
            logEmployee.ManagerID = employee.ManagerID;
            logEmployee.TeamMemberPhoto = employee.TeamMemberPhoto;
            logEmployee.FavoriteColorID = employee.FavoriteColorID;
            logEmployee.PreferredPhoneID = employee.PreferredPhoneID;

            _hrDbContext.LogEmployees.Add(logEmployee);
            return await _dbContext.SaveChangesAsync();
        }        
    }
}
