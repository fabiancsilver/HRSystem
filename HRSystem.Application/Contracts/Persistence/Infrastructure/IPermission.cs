using HRSystem.Application.Contracts.Persistence;
using HRSystem.Domain.Infrastructure;

namespace HRSystem.Application.Contracts.Persistence.Infrastructure
{
    public interface IPermissionRepository : IInfrastructureAsyncRepository<Permission>
    {

    }
}
