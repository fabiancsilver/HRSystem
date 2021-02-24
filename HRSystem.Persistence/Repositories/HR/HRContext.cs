using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using HRSystem.Domain.Report;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Persistence.HR
{
    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("HR");

            modelBuilder.Entity<Employee>().ToTable("Employees");

            modelBuilder.Entity<LogEmployee>().ToTable("LogEmployees");

            modelBuilder.Entity<Phone>().ToTable("Phones");

            modelBuilder.Entity<PhoneType>().ToTable("PhoneTypes");
            modelBuilder.Entity<PhoneType>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Address>().ToTable("Addresses");

            modelBuilder.Entity<AddressType>().ToTable("AddressTypes");
            modelBuilder.Entity<AddressType>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Email>().ToTable("Emails");
            modelBuilder.Entity<Email>().HasIndex(s => s.EmailAddress).IsUnique();

            modelBuilder.Entity<EmailType>().ToTable("EmailTypes");
            modelBuilder.Entity<EmailType>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Position>().ToTable("Positions");
            modelBuilder.Entity<Position>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Department>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Status>().ToTable("Statuses");
            modelBuilder.Entity<Status>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Shift>().ToTable("Shifts");
            modelBuilder.Entity<Shift>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Color>().ToTable("Colors");
            modelBuilder.Entity<Color>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Permission>().ToTable("Permissions");

            modelBuilder.Entity<PermissionEmployee>().ToTable("PermissionEmployee");
            modelBuilder.Entity<PermissionEmployee>()
                        .HasKey(s => new { s.PermissionID,s.EmployeeID });


            modelBuilder.Entity<Notification>().ToTable("Notifications");

            modelBuilder.Entity<NotificationEmployee>().ToTable("NotificationEmployee");
            modelBuilder.Entity<NotificationEmployee>()
                        .HasKey(s => new { s.NotificationID, s.EmployeeID });



            modelBuilder.Entity<WeeklyHireNumber>(
            eb =>
            {
                eb.HasNoKey();
                eb.ToView("WeeklyHireNumberView");
            });


            modelBuilder.Entity<TerminatedNumber>(
               eb =>
               {
                   eb.HasNoKey();
                   eb.ToView("TerminatedNumberView");
               });

            modelBuilder.Entity<NumberOfEmployeeDepartment>(
              eb =>
              {
                  eb.HasNoKey();
                  eb.ToView("NumberOfEmployeeDepartmentView");
              });

            modelBuilder.Entity<NumberOfEmployeeManager>(
              eb =>
              {
                  eb.HasNoKey();
                  eb.ToView("NumberOfEmployeeManagerView");
              });

            modelBuilder.Entity<RetentionRate>(
              eb =>
              {
                  eb.HasNoKey();
                  eb.ToView("RetentionRateView");
              });            
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<LogEmployee> LogEmployees { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<PhoneType> PhoneTypes { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<EmailType> EmailTypes { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionEmployee> PermissionEmployee { get; set; }


        public DbSet<Notification> Notifications { get; set; }

        public DbSet<NotificationEmployee> NotificationEmployee { get; set; }



        public DbSet<RetentionRate> RetentionRate { get; set; }

        public DbSet<WeeklyHireNumber> WeeklyHireNumbers { get; set; }

        public DbSet<TerminatedNumber> TerminatedNumbers { get; set; }

        public DbSet<NumberOfEmployeeDepartment> NumberOfEmployeeDepartments { get; set; }

        public DbSet<NumberOfEmployeeManager> NumberOfEmployeeManagers { get; set; }
    }
}