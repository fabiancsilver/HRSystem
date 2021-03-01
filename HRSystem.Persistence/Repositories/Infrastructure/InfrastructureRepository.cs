using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Persistence.Infrastructure;

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