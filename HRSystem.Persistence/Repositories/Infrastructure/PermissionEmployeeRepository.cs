using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.Infrastructure;
using HRSystem.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.Persistence.Repositories.HR
{
    public class PermissionEmployeeRepository : InfrastructureRepository<PermissionEmployee>, IPermissionEmployeeRepository
    {

        InfrastructureContext _infrastructureDbcontext;

        public PermissionEmployeeRepository(InfrastructureContext context) : base(context)
        {
            _infrastructureDbcontext = context;
        }

        public async Task<int> Count()
        {
            return await _infrastructureDbcontext.Notifications.CountAsync();
        }

        public override async Task<IEnumerable<PermissionEmployee>> GetAll(QueryParameters queryParameters)
        {
            return await _infrastructureDbcontext.PermissionEmployee
                                                 .Include(x => x.Employee)
                                                 .Include(x => x.Permission)
                                                 .ToListAsync();
        }

        public async Task<IEnumerable<PermissionEmployee>> ByEmployee(int employeeID)
        {
            return await _infrastructureDbcontext.PermissionEmployee
                                                 .Include(x => x.Employee)
                                                 .Include(x => x.Permission)
                                                 .Where(x => x.EmployeeID == employeeID)
                                                 .ToListAsync();
        }
    }
}
