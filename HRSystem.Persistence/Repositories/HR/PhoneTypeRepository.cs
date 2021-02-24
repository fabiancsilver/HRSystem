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
    public class PhoneTypeRepository : IPhoneTypeRepository
    {
        protected readonly HRContext _context;

        public PhoneTypeRepository(HRContext context)
        {
            _context = context;
        }

        public void Create(PhoneType entity)
        {
            _context.PhoneTypes.Add(entity);
        }

        public async Task<IEnumerable<PhoneType>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "PhoneTypeID", "PhoneTypeID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _context.PhoneTypes
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<PhoneType> GetById(int id)
        {
            return await _context.PhoneTypes.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await _context.PhoneTypes.FindAsync(id);
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

        public void Update(int id, PhoneType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
