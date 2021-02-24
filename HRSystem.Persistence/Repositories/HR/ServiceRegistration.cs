using HRSystem.Application.Repositories;
using HRSystem.Persistence.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRSystem.Persistence.Repositories.HR
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddHRPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


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

            return services;
        }
    }
}
