using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
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
    public class EmployeeRepository : HRRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(HRContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Employee>> GetAll(QueryParameters queryParameters)
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

            return await _hrDbContext.Employees
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



        public async Task UpdatePhoto(int employeeID, string pathPhoto)
        {
            var employee = await _hrDbContext.Employees
                                         .FindAsync(employeeID);

            if (employee == null)
            {
                throw new ArgumentException();
            }

            employee.TeamMemberPhoto = pathPhoto;
        }
    }
}
