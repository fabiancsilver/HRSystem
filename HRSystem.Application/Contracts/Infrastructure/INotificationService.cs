namespace HRSystem.Application.Contracts.Infrastructure
{
    public interface INotificationService
    {
        void SendNotificaion(string eventType);
    }
}
