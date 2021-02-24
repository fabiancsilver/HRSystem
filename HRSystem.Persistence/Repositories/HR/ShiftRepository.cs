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
    public class ShiftRepository : BaseRepository<Shift>, IShiftRepository
    {
        public ShiftRepository(HRContext context) : base(context)
        {
            
        }       

        public override async Task<IEnumerable<Shift>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "ShiftID", "ShiftID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _dbContext.Shifts
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }
    }
}
