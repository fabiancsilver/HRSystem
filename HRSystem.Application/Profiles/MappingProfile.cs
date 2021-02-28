using AutoMapper;
using HRSystem.Application.Features.Addresses.Commands.CreateAddress;
using HRSystem.Application.Features.Addresses.Commands.UpdateAddress;
using HRSystem.Application.Features.Addresses.Queries.GetAddressByEmployee;
using HRSystem.Application.Features.Addresses.Queries.GetByEmployee;
using HRSystem.Application.Features.AddressTypes.Commands.CreateAddressType;
using HRSystem.Application.Features.AddressTypes.Commands.DeleteAddressType;
using HRSystem.Application.Features.AddressTypes.Commands.UpdateAddressType;
using HRSystem.Application.Features.AddressTypes.Queries.GetAddressType;
using HRSystem.Application.Features.AddressTypes.Queries.GetAddressTypes;
using HRSystem.Application.Features.Colors.Commands.CreateColor;
using HRSystem.Application.Features.Colors.Commands.DeleteColor;
using HRSystem.Application.Features.Colors.Commands.UpdateColor;
using HRSystem.Application.Features.Colors.Queries.GetColor;
using HRSystem.Application.Features.Colors.Queries.GetColors;
using HRSystem.Application.Features.Departments.Commands.CreateDepartment;
using HRSystem.Application.Features.Departments.Commands.DeleteDepartment;
using HRSystem.Application.Features.Departments.Commands.UpdateDepartment;
using HRSystem.Application.Features.Departments.Queries.GetDepartment;
using HRSystem.Application.Features.Emails.Commands.CreateEmail;
using HRSystem.Application.Features.Emails.Commands.UpdateEmail;
using HRSystem.Application.Features.Emails.Queries.GetEmailByEmployee;
using HRSystem.Application.Features.EmailTypes.Commands.CreateEmailType;
using HRSystem.Application.Features.EmailTypes.Commands.DeleteEmailType;
using HRSystem.Application.Features.EmailTypes.Commands.UpdateEmailType;
using HRSystem.Application.Features.EmailTypes.Queries.GetEmailType;
using HRSystem.Application.Features.EmailTypes.Queries.GetEmailTypes;
using HRSystem.Application.Features.Employees.Commands.CreateEmployee;
using HRSystem.Application.Features.Employees.Commands.DeleteEmployee;
using HRSystem.Application.Features.Employees.Commands.UpdateEmployee;
using HRSystem.Application.Features.Employees.Queries.GetEmployee;
using HRSystem.Application.Features.Employees.Queries.GetEmployees;
using HRSystem.Application.Features.GetDepartments.Queries.GetDepartments;
using HRSystem.Application.Features.Infrastructure.PermissionEmployees.Queries.GetPermissionEmployees;
using HRSystem.Application.Features.Notifications.Queries.GetNotifications;
using HRSystem.Application.Features.Phones.Commands.CreatePhone;
using HRSystem.Application.Features.Phones.Commands.UpdatePhone;
using HRSystem.Application.Features.Phones.Queries.GetPhoneByEmployee;
using HRSystem.Application.Features.PhoneTypes.Commands.CreatePhoneType;
using HRSystem.Application.Features.PhoneTypes.Commands.DeletePhoneType;
using HRSystem.Application.Features.PhoneTypes.Commands.UpdatePhoneType;
using HRSystem.Application.Features.PhoneTypes.Queries.GetPhoneType;
using HRSystem.Application.Features.PhoneTypes.Queries.GetPhoneTypes;
using HRSystem.Application.Features.Positions.Commands.CreatePosition;
using HRSystem.Application.Features.Positions.Commands.DeletePosition;
using HRSystem.Application.Features.Positions.Commands.UpdatePosition;
using HRSystem.Application.Features.Positions.Queries.GetPosition;
using HRSystem.Application.Features.Positions.Queries.GetPositions;
using HRSystem.Application.Features.Shifts.Commands.CreateShift;
using HRSystem.Application.Features.Shifts.Commands.DeleteShift;
using HRSystem.Application.Features.Shifts.Commands.UpdateShift;
using HRSystem.Application.Features.Shifts.Queries.GetShift;
using HRSystem.Application.Features.Shifts.Queries.GetShifts;
using HRSystem.Application.Features.Statuses.Commands.CreateStatus;
using HRSystem.Application.Features.Statuses.Commands.DeleteStatus;
using HRSystem.Application.Features.Statuses.Commands.UpdateStatus;
using HRSystem.Application.Features.Statuses.Queries.GetStatus;
using HRSystem.Application.Features.Statuses.Queries.GetStatuses;
using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using System.Collections.Generic;

namespace HRSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, GetEmployeeQuery>().ReverseMap();
            CreateMap<Employee, GetEmployeeVm>().ReverseMap();
            CreateMap<Employee, GetEmployeesQuery>().ReverseMap();
            CreateMap<Employee, GetEmployeesVm>().ReverseMap();
            CreateMap<Position, GetEmployeesPositionDto>().ReverseMap();
            CreateMap<Department, GetEmployeesDepartmentDto>().ReverseMap();
            CreateMap<Status, GetEmployeesStatusDto>().ReverseMap();
            CreateMap<Shift, GetEmployeesShiftDto>().ReverseMap();
            CreateMap<Employee, GetEmployeesEmployeeDto>().ReverseMap();
            CreateMap<Color, GetEmployeesColorDto>().ReverseMap();
            
            //CreateMap<ICollection<Employee>, ICollection<GetEmployeesVm>().ReverseMap();


            CreateMap<Employee, CreateEmployeeDto>();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeDto>();
            CreateMap<Employee, DeleteEmployeeCommand>().ReverseMap();

            CreateMap<AddressType, GetAddressTypeQuery>().ReverseMap();
            CreateMap<AddressType, GetAddressTypeVm>().ReverseMap();
            CreateMap<AddressType, GetAddressTypesQuery>().ReverseMap();
            CreateMap<AddressType, GetAddressTypesVm>().ReverseMap();
            CreateMap<AddressType, CreateAddressTypeDto>();
            CreateMap<AddressType, CreateAddressTypeCommand>().ReverseMap();
            CreateMap<AddressType, UpdateAddressTypeDto>();
            CreateMap<AddressType, UpdateAddressTypeCommand>().ReverseMap();
            CreateMap<AddressType, DeleteAddressTypeDto>();
            CreateMap<AddressType, DeleteAddressTypeCommand>().ReverseMap();
            
            CreateMap<Address, GetAddressByEmployeeVm>().ReverseMap();            
            CreateMap<Address, CreateAddressDto>();
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<AddressType, AddressTypeDto>().ReverseMap();
            CreateMap<Address, UpdateAddressDto>();
            CreateMap<Address, UpdateEmailCommand>().ReverseMap();           

            CreateMap<Department, GetDepartmentQuery>().ReverseMap();
            CreateMap<Department, GetDepartmentVm>().ReverseMap();
            CreateMap<Department, GetDepartmentsQuery>().ReverseMap();
            CreateMap<Department, GetDepartmentsVm>().ReverseMap();
            CreateMap<Department, CreateDepartmentDto>();
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>();
            CreateMap<Department, UpdateDepartmentCommand>().ReverseMap();
            CreateMap<Department, DeleteDepartmentDto>();
            CreateMap<Department, DeleteDepartmentCommand>().ReverseMap();

            CreateMap<Color, GetColorQuery>().ReverseMap();
            CreateMap<Color, GetColorVm>().ReverseMap();
            CreateMap<Color, GetColorsQuery>().ReverseMap();
            CreateMap<Color, GetColorsVm>().ReverseMap();
            CreateMap<Color, CreateColorDto>();
            CreateMap<Color, CreateColorCommand>().ReverseMap();
            CreateMap<Color, UpdateColorDto>();
            CreateMap<Color, UpdateColorCommand>().ReverseMap();
            CreateMap<Color, DeleteColorDto>();
            CreateMap<Color, DeleteColorCommand>().ReverseMap();

            CreateMap<Email, GetEmailsByEmployeeVm>().ReverseMap();
            CreateMap<Email, CreateEmailDto>();
            CreateMap<Email, CreateEmailCommand>().ReverseMap();            
            CreateMap<Email, UpdateEmailDto>();
            CreateMap<Email, UpdateEmailCommand>().ReverseMap();

            CreateMap<EmailType, GetEmailTypeQuery>().ReverseMap();
            CreateMap<EmailType, GetEmailTypeVm>().ReverseMap();
            CreateMap<EmailType, GetEmailTypesQuery>().ReverseMap();
            CreateMap<EmailType, GetEmailTypesVm>().ReverseMap();
            CreateMap<EmailType, CreateEmailTypeDto>();
            CreateMap<EmailType, CreateEmailTypeCommand>().ReverseMap();
            CreateMap<EmailType, UpdateEmailTypeDto>();
            CreateMap<EmailType, UpdateEmailTypeCommand>().ReverseMap();
            CreateMap<EmailType, DeleteEmailTypeDto>();
            CreateMap<EmailType, DeleteEmailTypeCommand>().ReverseMap();

            CreateMap<Phone, GetPhonesByEmployeeVm>().ReverseMap();
            CreateMap<Phone, CreatePhoneDto>();
            CreateMap<Phone, CreatePhoneCommand>().ReverseMap();
            CreateMap<Phone, UpdatePhoneDto>();
            CreateMap<Phone, UpdatePhoneCommand>().ReverseMap();

            CreateMap<PhoneType, GetPhoneTypeQuery>().ReverseMap();
            CreateMap<PhoneType, GetPhoneTypeVm>().ReverseMap();
            CreateMap<PhoneType, GetPhoneTypesQuery>().ReverseMap();
            CreateMap<PhoneType, GetPhoneTypesVm>().ReverseMap();
            CreateMap<PhoneType, CreatePhoneTypeDto>();
            CreateMap<PhoneType, CreatePhoneTypeCommand>().ReverseMap();
            CreateMap<PhoneType, UpdatePhoneTypeDto>();
            CreateMap<PhoneType, UpdatePhoneTypeCommand>().ReverseMap();
            CreateMap<PhoneType, DeletePhoneTypeDto>();
            CreateMap<PhoneType, DeletePhoneTypeCommand>().ReverseMap();

            CreateMap<Shift, GetShiftQuery>().ReverseMap();
            CreateMap<Shift, GetShiftVm>().ReverseMap();
            CreateMap<Shift, GetShiftsQuery>().ReverseMap();
            CreateMap<Shift, GetShiftsVm>().ReverseMap();
            CreateMap<Shift, CreateShiftDto>();
            CreateMap<Shift, CreateShiftCommand>().ReverseMap();
            CreateMap<Shift, UpdateShiftDto>();
            CreateMap<Shift, UpdateShiftCommand>().ReverseMap();
            CreateMap<Shift, DeleteShiftDto>();
            CreateMap<Shift, DeleteShiftCommand>().ReverseMap();

            CreateMap<Status, GetStatusQuery>().ReverseMap();
            CreateMap<Status, GetStatusVm>().ReverseMap();
            CreateMap<Status, GetStatusesQuery>().ReverseMap();
            CreateMap<Status, GetStatusesVm>().ReverseMap();
            CreateMap<Status, CreateStatusDto>();
            CreateMap<Status, CreateStatusCommand>().ReverseMap();
            CreateMap<Status, UpdateStatusDto>();
            CreateMap<Status, UpdateStatusCommand>().ReverseMap();
            CreateMap<Status, DeleteStatusDto>();
            CreateMap<Status, DeleteStatusCommand>().ReverseMap();

            CreateMap<Position, GetPositionQuery>().ReverseMap();
            CreateMap<Position, GetPositionVm>().ReverseMap();
            CreateMap<Position, GetPositionsQuery>().ReverseMap();
            CreateMap<Position, GetPositionsVm>().ReverseMap();
            CreateMap<Position, CreatePositionDto>();
            CreateMap<Position, CreatePositionCommand>().ReverseMap();
            CreateMap<Position, UpdatePositionDto>();
            CreateMap<Position, UpdatePositionCommand>().ReverseMap();
            CreateMap<Position, DeletePositionDto>();
            CreateMap<Position, DeletePositionCommand>().ReverseMap();


            CreateMap<Permission, GetPermissionEmployeesPermissionDto>().ReverseMap();
            CreateMap<Employee, GetPermissionEmployeesEmployeeDto>().ReverseMap();

            CreateMap<PermissionEmployee, GetPermissionEmployeesVm>().ReverseMap();


        }
    }
}
