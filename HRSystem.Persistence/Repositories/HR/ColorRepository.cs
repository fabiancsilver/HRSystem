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
    public class ColorRepository : IColorRepository
    {
        protected readonly HRContext _context;

        public ColorRepository(HRContext context)
        {
            _context = context;
        }

        public void Create(Color entity)
        {
            _context.Colors.Add(entity);
        }

        public Task<Color> FirstOrDefault(Expression<Func<Color, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Color>> GetAll(QueryParameters queryParameters)
        {
            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "ColorID", "ColorID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _context.Colors
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<Color> GetById(int id)
        {
            return await _context.Colors.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await _context.Colors.FindAsync(id);
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

        public void Update(int id, Color entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
