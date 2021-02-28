using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, DeleteDepartmentCommandResponse>
    {
        private readonly IHRAsyncRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public DeleteDepartmentCommandHandler(IMapper mapper, IHRAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<DeleteDepartmentCommandResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteDepartmentCommandResponse();

            var validator = new DeleteDepartmentCommandValidator();
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
                await _departmentRepository.Remove(department.DepartmentID);
                await _departmentRepository.SaveChanges();

                response.Department = _mapper.Map<DeleteDepartmentDto>(department);
            }

            return response;
        }
    }
}
