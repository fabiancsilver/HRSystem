using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandResponse : BaseResponse
    {
        public CreateNotificationCommandResponse() : base()
        {

        }

        public CreateNotificationDto Notification { get; set; }
    }
}