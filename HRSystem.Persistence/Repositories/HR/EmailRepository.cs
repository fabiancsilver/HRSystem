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
    public class EmailRepository : IEmailRepository
    {
        protected readonly HRContext _context;

        public EmailRepository(HRContext context)
        {
            _context = context;
        }

        public void Create(Email entity)
        {
            _context.Emails.Add(entity);
        }

        public async Task<IEnumerable<Email>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "EmailAddress", "EmailAddress" },
                { "EmailID", "EmailID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "EmailAddress", "EmailAddress" }
            };

            var list = _context.Emails
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<ICollection<Email>> GetAllByEmployee(int employeeID)
        {

            var list = _context.Emails.Where(x => x.EmployeeID == employeeID);

            return await list.ToListAsync();
        }


        public async Task<Email> GetById(int id)
        {
            return await _context.Emails.FindAsync(id);
        }

        public async Task<Email> GetByEmployee(int employeeID)
        {
            return await _context.Emails.FirstOrDefaultAsync(x => x.EmployeeID == employeeID);
        }

        public async Task Remove(int id)
        {
            var item = await _context.Emails.FindAsync(id);
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

        public void Update(int id, Email entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }


    }
}
