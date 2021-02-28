using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentCommandResponse>
    {
        private readonly IHRAsyncRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IMapper mapper, IHRAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateDepartmentCommandResponse();

            var validator = new CreateDepartmentCommandValidator();
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
                _departmentRepository.Create(department);
                await _departmentRepository.SaveChanges();

                response.Department = _mapper.Map<CreateDepartmentDto>(department);
            }

            return response;
        }
    }
}
