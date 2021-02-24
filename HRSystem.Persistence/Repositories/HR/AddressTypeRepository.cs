using HRSystem.Application.Common;
using HRSystem.Application.Repositories;
using HRSystem.Domain.HR;
using HRSystem.Persistence.Common;
using HRSystem.Persistence.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRSystem.Persistence.Repositories.HR
{
    public class AddressTypeRepository : BaseRepository<AddressType>, IAddressTypeRepository
    {
        public AddressTypeRepository(HRContext dbContext) : base(dbContext)
        {

        }

        public override async Task<IEnumerable<AddressType>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "AddressTypeID", "AddressTypeID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _dbContext.AddressTypes
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }
    }
}
