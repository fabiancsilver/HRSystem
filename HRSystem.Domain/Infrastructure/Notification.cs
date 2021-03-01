using System.ComponentModel.DataAnnotations;

namespace HRSystem.Domain.Infrastructure
{
    public class Notification
    {
        public int NotificationID { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
    }
}
