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
    public class AddressRepository : HRRepository<Address>, IAddressRepository
    {
        
        public AddressRepository(HRContext context)  : base(context)
        {
           
        }    

        public override async Task<IEnumerable<Address>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Line1", "Line1" },
                { "AddressID", "AddressID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Line1", "Line1" }
            };

            var list = _hrDbContext.Addresses
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }
        

        public async Task<Address> GetByEmployee(int employeeID)
        {
            return await _hrDbContext.Addresses
                                   .FirstOrDefaultAsync(x => x.EmployeeID == employeeID);
        }        
    }
}
