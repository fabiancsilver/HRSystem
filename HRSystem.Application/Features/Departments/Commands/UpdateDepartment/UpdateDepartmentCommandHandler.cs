using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, UpdateDepartmentCommandResponse>
    {
        private readonly IHRAsyncRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IMapper mapper, IHRAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<UpdateDepartmentCommandResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateDepartmentCommandResponse();

            var validator = new UpdateDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                var department = _mapper.Map<Department>(request);
                _departmentRepository.Update(department.DepartmentID, department);
                await _departmentRepository.SaveChanges();

                response.Department = _mapper.Map<UpdateDepartmentDto>(department);
            }

            return response;
        }
    }
}
