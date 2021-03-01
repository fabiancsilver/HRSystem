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
    public class StatusRepository : HRRepository<Status>, IStatusRepository
    {
        public StatusRepository(HRContext hrDbContext) : base(hrDbContext)
        {

        }

        public override async Task<IEnumerable<Status>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "StatusID", "StatusID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _hrDbContext.Statuses
                                    .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                                    .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                                    .AsQueryable();


            return await list.ToListAsync();
        }
    }
}
