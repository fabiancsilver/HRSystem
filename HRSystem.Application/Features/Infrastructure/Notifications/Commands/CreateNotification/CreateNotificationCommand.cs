using MediatR;

namespace HRSystem.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommand : IRequest<CreateNotificationCommandResponse>
    {
        public string Name { get; set; }
    }
}
