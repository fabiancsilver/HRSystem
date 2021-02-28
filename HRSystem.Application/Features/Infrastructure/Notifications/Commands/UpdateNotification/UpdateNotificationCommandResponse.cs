using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Notifications.Commands.UpdateNotification
{
    public class UpdateNotificationCommandResponse : BaseResponse
    {
        public UpdateNotificationCommandResponse() : base()
        {

        }

        public UpdateNotificationDto Notification { get; set; }
    }
}