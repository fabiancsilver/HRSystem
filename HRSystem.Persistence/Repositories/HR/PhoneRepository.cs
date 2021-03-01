using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using HRSystem.Persistence.Common;
using HRSystem.Persistence.HR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.Persistence.Repositories.HR
{
    public class PhoneRepository : HRRepository<Phone>, IPhoneRepository
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

            var list = _hrDbContext.Phones
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<ICollection<Phone>> GetAllByEmployee(int employeeID)
        {

            var list = _hrDbContext.Phones.Where(x => x.EmployeeID == employeeID);

            return await list.ToListAsync();
        }

        public async Task<Phone> GetByEmployee(int employeeID)
        {
            return await _hrDbContext.Phones.FirstOrDefaultAsync(x => x.EmployeeID == employeeID);
        }
    }
}
