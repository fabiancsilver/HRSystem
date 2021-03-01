using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.GetDepartments.Queries.GetDepartments
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, IEnumerable<GetDepartmentsVm>>
    {
        private readonly IHRAsyncRepository<Department> _departmentRepository;

        private readonly IMapper _mapper;

        public GetDepartmentsQueryHandler(IMapper mapper, IHRAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<GetDepartmentsVm>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var departments = await _departmentRepository.GetAll(queryParameters);
            var departmentsVm = _mapper.Map<IEnumerable<GetDepartmentsVm>>(departments);

            return departmentsVm;
        }
    }
}
