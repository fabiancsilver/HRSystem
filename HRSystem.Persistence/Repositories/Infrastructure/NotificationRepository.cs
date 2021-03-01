using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.Infrastructure;
using HRSystem.Persistence.Infrastructure;

namespace HRSystem.Persistence.Repositories.HR
{
    public class NotificationRepository : InfrastructureRepository<Notification>, INotificationRepository
    {



        public NotificationRepository(InfrastructureContext context) : base(context)
        {

        }


    }
}
