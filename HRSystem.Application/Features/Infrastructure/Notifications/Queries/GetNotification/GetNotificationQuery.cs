using MediatR;

namespace HRSystem.Application.Features.Notifications.Queries.GetNotification
{
    public class GetNotificationQuery : IRequest<GetNotificationVm>
    {
        public int NotificationID { get; set; }
    }
}
