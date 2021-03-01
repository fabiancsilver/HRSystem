using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Persistence.Infrastructure
{
    public class InfrastructureContext : DbContext
    {
        public InfrastructureContext(DbContextOptions<InfrastructureContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Infrastructure");

            modelBuilder.Entity<Permission>().ToTable("Permissions");

            modelBuilder.Entity<PermissionEmployee>().ToTable("PermissionEmployee");
            modelBuilder.Entity<PermissionEmployee>()
                        .HasKey(s => new { s.PermissionID, s.EmployeeID });


            modelBuilder.Entity<Notification>().ToTable("Notifications");

            modelBuilder.Entity<NotificationEmployee>().ToTable("NotificationEmployee");
            modelBuilder.Entity<NotificationEmployee>()
                        .HasKey(s => new { s.NotificationID, s.EmployeeID });


            modelBuilder.Entity<Employee>().ToTable("Employees", "HR");

        }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionEmployee> PermissionEmployee { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<NotificationEmployee> NotificationEmployee { get; set; }
    }
}