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
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        

        public DepartmentRepository(HRContext context) : base(context)
        {
        
        }

        public override async Task<IEnumerable<Department>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "DepartmentID", "DepartmentID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _dbContext.Departments
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }
    }
}
