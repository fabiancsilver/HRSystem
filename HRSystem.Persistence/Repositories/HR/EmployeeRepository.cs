using HRSystem.Application.Common;
using HRSystem.Application.Repositories;
using HRSystem.Domain.HR;
using HRSystem.Persistence.Common;
using HRSystem.Persistence.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.Persistence.Repositories.HR
{
    public class EmployeeRepository : IEmployeeRepository
    {

        protected readonly HRContext _context;

        public EmployeeRepository(HRContext context)
        {
            _context = context;
        }

        public void Create(Employee entity)
        {
            _context.Employees.Add(entity);
        }

        public async Task<IEnumerable<Employee>> GetAll(QueryParameters queryParameters)
        {
            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "EmployeeID", "EmployeeID" },
                { "StartDate", "StartDate" },
                { "EndDate", "EndDate" },
                { "Position", "Position.Name" },
                { "Department", "Department.Name"},
                { "Shift", "Shift.Name" },
                { "Manager", "Manager.Name" },
                { "Color", "FavoriteColor.Name" },
                { "Status", "Status.Name" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "Position", "Position.Name" },
                { "Department", "Department.Name"},
                { "Shift", "Shift.Name" },
                { "Manager", "Manager.Name" },
                { "Color", "FavoriteColor.Name" },
                { "Status", "Status.Name" }
            };

            return await _context.Employees
                                 .Include(x => x.Position)
                                 .Include(x => x.Department)
                                 .Include(x => x.Shift)
                                 .Include(x => x.Manager)
                                 .Include(x => x.FavoriteColor)
                                 .Include(x => x.Status)
                                 .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                                 .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                                 .AsQueryable()
                                 .ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await _context.Employees.FindAsync(id);
            if (item == null)
            {
                throw new ArgumentException();
            }
            _context.Remove(item);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(int id, Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdatePhoto(int employeeID, string pathPhoto)
        {
            var employee = await _context.Employees
                                         .FindAsync(employeeID);

            if (employee == null)
            {
                throw new ArgumentException();
            }

            employee.TeamMemberPhoto = pathPhoto;            
        }
    }
}
