using HRSystem.Application.Common;
using HRSystem.Application.Repositories;
using HRSystem.Domain.HR;
using HRSystem.Persistence.HR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.Persistence.Repositories.HR
{
    public class LogEmployeeRepository : ILogEmployeeRepository
    {

        protected readonly HRContext _context;

        public LogEmployeeRepository(HRContext context)
        {
            _context = context;
        }

        public void Create(LogEmployee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
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

            _context.LogEmployees.Add(logEmployee);
            return await _context.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LogEmployee>> GetAll(QueryParameters queryParameters)
        {
            throw new NotImplementedException();
        }

        public Task<LogEmployee> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, LogEmployee entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
