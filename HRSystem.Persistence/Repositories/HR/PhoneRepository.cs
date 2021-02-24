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
    public class PhoneRepository : IPhoneRepository
    {
        protected readonly HRContext _context;

        public PhoneRepository(HRContext context)
        {
            _context = context;
        }

        public void Create(Phone entity)
        {
            _context.Phones.Add(entity);
        }

        public async Task<IEnumerable<Phone>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "PhoneNumber", "PhoneNumber" },
                { "PhoneID", "PhoneID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "PhoneNumber", "PhoneNumber" }
            };

            var list = _context.Phones
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<ICollection<Phone>> GetAllByEmployee(int employeeID)
        {

            var list = _context.Phones.Where(x => x.EmployeeID == employeeID);

            return await list.ToListAsync();
        }


        public async Task<Phone> GetById(int id)
        {
            return await _context.Phones.FindAsync(id);
        }

        public async Task<Phone> GetByEmployee(int employeeID)
        {
            return await _context.Phones.FirstOrDefaultAsync(x => x.EmployeeID == employeeID);
        }

        public async Task Remove(int id)
        {
            var item = await _context.Phones.FindAsync(id);
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

        public void Update(int id, Phone entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }


    }
}
