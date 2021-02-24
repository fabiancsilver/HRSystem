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
    public class ShiftRepository : IShiftRepository
    {
        protected readonly HRContext _context;

        public ShiftRepository(HRContext context)
        {
            _context = context;
        }

        public void Create(Shift entity)
        {
            _context.Shifts.Add(entity);
        }

        public async Task<IEnumerable<Shift>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "ShiftID", "ShiftID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _context.Shifts
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<Shift> GetById(int id)
        {
            return await _context.Shifts.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await _context.Shifts.FindAsync(id);
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

        public void Update(int id, Shift entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
