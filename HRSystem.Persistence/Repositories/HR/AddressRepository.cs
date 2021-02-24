﻿using HRSystem.Application.Common;
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
    public class AddressRepository : IAddressRepository
    {
        protected readonly HRContext _context;

        public AddressRepository(HRContext context)
        {
            _context = context;
        }

        public void Create(Address entity)
        {
            _context.Addresses.Add(entity);
        }

        public async Task<IEnumerable<Address>> GetAll(QueryParameters queryParameters)
        {

            Dictionary<string, string> dictionarySort = new Dictionary<string, string>() {
                { "Line1", "Line1" },
                { "AddressID", "AddressID" }
            };

            Dictionary<string, string> dictionaryFilter = new Dictionary<string, string>() {
                { "Line1", "Line1" }
            };

            var list = _context.Addresses
                               .ApplySort(queryParameters.SortBy, queryParameters.Direction, dictionarySort)
                               .ApplyFilter(queryParameters.FilterBy, dictionaryFilter)
                               .AsQueryable();


            return await list.ToListAsync();
        }

        public async Task<Address> GetById(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<Address> GetByEmployee(int employeeID)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.EmployeeID == employeeID);
        }

        public async Task Remove(int id)
        {
            var item = await _context.Addresses.FindAsync(id);
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

        public void Update(int id, Address entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
