using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using HRSystem.Persistence.HR;
using System.Linq;

namespace HRSystem.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(HRContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Colors.Any())
            {
                var colors = new Color[]
                    {
                        new Color{Name = "Red"},
                        new Color{Name = "Black"},
                    };

                foreach (Color color in colors)
                {
                    context.Colors.Add(color);
                }
                context.SaveChanges();
            }

            if (!context.Positions.Any())
            {
                var positions = new Position[]
                    {                        
                        new Position{Name = "Manager"},                     
                        new Position{Name = "Agent"},
                    };

                foreach (Position position in positions)
                {
                    context.Positions.Add(position);
                }
                context.SaveChanges();
            }

            if (!context.EmailTypes.Any())
            {
                var emailTypes = new EmailType[]
                    {
                        new EmailType{Name = "Personal"},
                        new EmailType{Name = "Work"}
                    };

                foreach (EmailType emailType in emailTypes)
                {
                    context.EmailTypes.Add(emailType);
                }
                context.SaveChanges();
            }

            if (!context.PhoneTypes.Any())
            {
                var phoneTypes = new PhoneType[]
                    {
                        new PhoneType{Name = "Home"},
                        new PhoneType{Name = "Mobile"},
                        new PhoneType{Name = "Work"},
                        new PhoneType{Name = "Fax"}
                    };

                foreach (PhoneType phoneType in phoneTypes)
                {
                    context.PhoneTypes.Add(phoneType);
                }
                context.SaveChanges();
            }

            if (!context.AddressTypes.Any())
            {
                var addressTypes = new AddressType[]
                    {
                        new AddressType{Name = "Home"},
                        new AddressType{Name = "Work"}
                    };

                foreach (AddressType addressType in addressTypes)
                {
                    context.AddressTypes.Add(addressType);
                }
                context.SaveChanges();
            }

            if (!context.Shifts.Any())
            {
                var shifts = new Shift[]
                    {
                        new Shift{Name = "Day"},
                        new Shift{Name = "Swing"},
                        new Shift{Name = "Night"},
                    };

                foreach (Shift shift in shifts)
                {
                    context.Shifts.Add(shift);
                }
                context.SaveChanges();
            }

            if (!context.Departments.Any())
            {
                var departments = new Department[]
                    {
                        new Department{Name = "IT"},
                        new Department{Name = "Sales"},
                        new Department{Name = "Production"},
                        new Department{Name = "Purchasing"},
                        new Department{Name = "Human Resources"},
                        new Department{Name = "Finance"},
                    };

                foreach (Department department in departments)
                {
                    context.Departments.Add(department);
                }
                context.SaveChanges();
            }

            if (!context.Statuses.Any())
            {
                var statuses = new Status[]
                    {
                        new Status{Name = "Active"},
                        new Status{Name = "Suspended"},
                        new Status{Name = "Terminated"}
                    };

                foreach (Status status in statuses)
                {
                    context.Statuses.Add(status);
                }
                context.SaveChanges();
            }

            if (!context.Permissions.Any())
            {
                var permissions = new Permission[]
                    {
                        new Permission{Name = "HR_EMPLOYEE_ADD"},
                        new Permission{Name = "HR_EMPLOYEE_MODIFY"},
                        new Permission{Name = "HR_EMPLOYEE_DELETE"},
                        new Permission{Name = "HR_STATUS_ADD"},
                        new Permission{Name = "HR_STATUS_MODIFY"},
                        new Permission{Name = "HR_STATUS_DELETE"},
                    };

                foreach (Permission permission in permissions)
                {
                    context.Permissions.Add(permission);
                }

                context.SaveChanges();
            }

            if (!context.Notifications.Any())
            {
                var notifications = new Notification[]
                    {
                        new Notification{Name = "HR_EMPLOYEE_ADDED"},
                        new Notification{Name = "HR_EMPLOYEE_MODIFIED"},
                        new Notification{Name = "HR_EMPLOYEE_DELETED"},
                    };

                foreach (Notification notification in notifications)
                {
                    context.Notifications.Add(notification);
                }

                context.SaveChanges();
            }
        }
    }
}