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
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        
        public PhoneRepository(HRContext context) : base(context)
        {
        
        }
        
        public override async Task<IEnumerable<Phone>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "PhoneNumber", "PhoneNumber" },
                { "PhoneID", "PhoneID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "PhoneNumber", "PhoneNumber" }
            };

            var list = _dbContext.Phones
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<ICollection<Phone>> GetAllByEmployee(int employeeID)
        {

            var list = _dbContext.Phones.Where(x => x.EmployeeID == employeeID);

            return await list.ToListAsync();
        }      

        public async Task<Phone> GetByEmployee(int employeeID)
        {
            return await _dbContext.Phones.FirstOrDefaultAsync(x => x.EmployeeID == employeeID);
        }
    }
}
