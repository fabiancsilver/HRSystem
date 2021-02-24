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
    public class EmailTypeRepository : IEmailTypeRepository
    {
        protected readonly HRContext _context;

        public EmailTypeRepository(HRContext context)
        {
            _context = context;
        }

        public void Create(EmailType entity)
        {
            _context.EmailTypes.Add(entity);
        }

        public async Task<IEnumerable<EmailType>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Name", "Name" },
                { "EmailTypeID", "EmailTypeID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Name", "Name" }
            };

            var list = _context.EmailTypes
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<EmailType> GetById(int id)
        {
            return await _context.EmailTypes.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var item = await _context.EmailTypes.FindAsync(id);
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

        public void Update(int id, EmailType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
