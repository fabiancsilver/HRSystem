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
    public class EmailRepository : HRRepository<Email>, IEmailRepository
    {        
        public EmailRepository(HRContext context) : base(context)
        {
     
        } 

        public override async Task<IEnumerable<Email>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "EmailAddress", "EmailAddress" },
                { "EmailID", "EmailID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "EmailAddress", "EmailAddress" }
            };

            var list = _hrDbContext.Emails
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<ICollection<Email>> GetAllByEmployee(int employeeID)
        {

            var list = _hrDbContext.Emails.Where(x => x.EmployeeID == employeeID);

            return await list.ToListAsync();
        }


        public async Task<Email> GetByEmployee(int employeeID)
        {
            return await _hrDbContext.Emails.FirstOrDefaultAsync(x => x.EmployeeID == employeeID);
        }
    }
}
