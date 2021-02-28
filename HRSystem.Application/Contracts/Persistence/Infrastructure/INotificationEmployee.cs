using HRSystem.Application.Contracts.Persistence;
using HRSystem.Domain.Infrastructure;
using System.Threading.Tasks;

namespace HRSystem.Application.Contracts.Persistence.Infrastructure
{
    public interface INotificationEmployeeRepository : IInfrastructureAsyncRepository<NotificationEmployee>
    {
        
    }
}
