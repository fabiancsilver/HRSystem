using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Notifications.Commands.DeleteNotification
{
    public class DeleteNotificationCommandResponse : BaseResponse
    {
        public DeleteNotificationCommandResponse() : base()
        {

        }

        public DeleteNotificationDto Notification { get; set; }
    }
}