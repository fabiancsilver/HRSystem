using HRSystem.Application.Contracts.Persistence;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Persistence.HR;
using HRSystem.Persistence.Infrastructure;
using HRSystem.Persistence.Repositories.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRSystem.Persistence.Repositories
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, 
                                                                IConfiguration configuration)
        {
            services.AddDbContext<HRContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<InfrastructureContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));            

            services.AddScoped(typeof(IHRAsyncRepository<>), typeof(HRRepository<>));
            services.AddScoped(typeof(IInfrastructureAsyncRepository<>), typeof(InfrastructureRepository<>));

            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            services.AddScoped(typeof(ILogEmployeeRepository), typeof(LogEmployeeRepository));
            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));
            services.AddScoped(typeof(IPhoneRepository), typeof(PhoneRepository));
            services.AddScoped(typeof(IEmailRepository), typeof(EmailRepository));
            services.AddScoped(typeof(IColorRepository), typeof(ColorRepository));
            services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository));
            services.AddScoped(typeof(IAddressTypeRepository), typeof(AddressTypeRepository));
            services.AddScoped(typeof(IEmailTypeRepository), typeof(EmailTypeRepository));
            services.AddScoped(typeof(IPhoneTypeRepository), typeof(PhoneTypeRepository));
            services.AddScoped(typeof(IPositionRepository), typeof(PositionRepository));
            services.AddScoped(typeof(IShiftRepository), typeof(ShiftRepository));
            services.AddScoped(typeof(IStatusRepository), typeof(StatusRepository));

            services.AddScoped(typeof(INotificationRepository), typeof(NotificationRepository));
            services.AddScoped(typeof(INotificationEmployeeRepository), typeof(NotificationEmployeeRepository));
            services.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
            services.AddScoped(typeof(IPermissionEmployeeRepository), typeof(PermissionEmployeeRepository));

            return services;
        }
    }
}
