using HRSystem.Application.Contracts.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace HRSystem.Persistence.Infrastructure
{
    public class NotificationService : INotificationService
    {
        private readonly InfrastructureContext _hrContext;
        private readonly IConfiguration _configuration;

        public NotificationService(InfrastructureContext hrContext,
                                   IConfiguration configuration)
        {
            _hrContext = hrContext;
            _configuration = configuration;
        }

        public void SendNotificaion(string eventType)
        {
            var notifications = _hrContext.NotificationEmployee
                                          .Include(x => x.Employee)
                                          .Include(x => x.Notification)
                                          .Where(x => x.Notification.Name == eventType)
                                          .ToList();

            //var folderName = Path.Combine("Resources", "Notifications");
            var folderName = Path.Combine(_configuration.GetSection("Paths:ResourcesFolder").Value, _configuration.GetSection("Paths:NotificationsFolder").Value);

            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            foreach (var notification in notifications)
            {
                var uniqueName = Guid.NewGuid().ToString();

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(pathToSave, $"{uniqueName}.txt")))
                {
                    outputFile.WriteLine("This text simulate a notification sent from HR System");
                    outputFile.WriteLine($"For: {notification.Employee.Name}");
                    outputFile.WriteLine($"About: {notification.Notification.Name}");
                }
            }
        }
    }
}
