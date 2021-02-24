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
    public class AddressTypeRepository : IAddressTypeRepository
    {
        protected readonly HRContext _context;

        public AddressTypeRepository(HRContext context)
        {
            _context = context;
        }

        public void Create(AddressType entity)
        {
            _context.AddressTypes.Add(entity);
        }

        public async Task<IEnumerable<AddressType>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "AddressTypeID", "AddressTypeID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _context.AddressTypes
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<AddressType> GetById(int id)
        {
            return await _context.AddressTypes.FindAsync(id);
        }

        public Task<IEnumerable<AddressType>> GetWhere(Expression<Func<AddressType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            var item = await _context.AddressTypes.FindAsync(id);
            if (item == null)
            {
                throw new ArgumentException();
            }
            _context.Remove(item);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(int id, AddressType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
