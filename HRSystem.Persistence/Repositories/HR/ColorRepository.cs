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
    public class ColorRepository : HRRepository<Color>, IColorRepository
    {

        public ColorRepository(HRContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Color>> GetAll(QueryParameters queryParameters)
        {
            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "ColorID", "ColorID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _hrDbContext.Colors
                                   .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                                   .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                                   .AsQueryable();


            return await list.ToListAsync();
        }
    }
}
