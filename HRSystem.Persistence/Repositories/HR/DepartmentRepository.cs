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
    public class DepartmentRepository : IDepartmentRepository
    {
        protected readonly HRContext _context;

        public DepartmentRepository(HRContext context)
        {
            _context = context;
        }


        public void Create(Department entity)
        {
            _context.Departments.Add(entity);
        }

        public async Task<IEnumerable<Department>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "DepartmentID", "DepartmentID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _context.Departments
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await _context.Departments.FindAsync(id);
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

        public void Update(int id, Department entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
