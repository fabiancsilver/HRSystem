using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.Infrastructure;
using HRSystem.Persistence.Infrastructure;

namespace HRSystem.Persistence.Repositories.HR
{
    public class PermissionRepository : InfrastructureRepository<Permission>, IPermissionRepository
    {

        public PermissionRepository(InfrastructureContext context) : base(context)
        {

        }
    }
}
