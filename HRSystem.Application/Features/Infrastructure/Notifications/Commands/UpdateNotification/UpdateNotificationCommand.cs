using MediatR;

namespace HRSystem.Application.Features.Notifications.Commands.UpdateNotification
{
    public class UpdateNotificationCommand : IRequest<UpdateNotificationCommandResponse>
    {
        public int NotificationID { get; set; }
        public string Name { get; set; }
    }
}
