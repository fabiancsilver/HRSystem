using MediatR;

namespace HRSystem.Application.Features.Notifications.Commands.DeleteNotification
{
    public class DeleteNotificationCommand : IRequest<DeleteNotificationCommandResponse>
    {
        public int NotificationID { get; set; }
    }
}
