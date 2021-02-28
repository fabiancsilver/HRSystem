using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.Persistence.Repositories
{
    public class InfrastructureRepository<T> : BaseRepository<T>, IInfrastructureAsyncRepository<T> where T : class
    {

        public readonly InfrastructureContext _infrastructureDbContext;

        public InfrastructureRepository(InfrastructureContext infrastructureDbContext) : base(infrastructureDbContext)
        {
            _infrastructureDbContext = infrastructureDbContext;
        }        
    }
}