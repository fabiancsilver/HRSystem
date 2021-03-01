using HRSystem.Domain.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.Application.Contracts.Persistence.Infrastructure
{
    public interface IPermissionEmployeeRepository : IInfrastructureAsyncRepository<PermissionEmployee>
    {
        Task<int> Count();

        Task<IEnumerable<PermissionEmployee>> ByEmployee(int employeeID);
    }
}
