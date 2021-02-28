using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.Infrastructure;
using HRSystem.Persistence.Infrastructure;
using System.Threading.Tasks;

namespace HRSystem.Persistence.Repositories.HR
{
    public class NotificationEmployeeRepository : InfrastructureRepository<NotificationEmployee>, INotificationEmployeeRepository
    {        

        public NotificationEmployeeRepository(InfrastructureContext context)  : base(context)
        {
            
        }
    }
}
