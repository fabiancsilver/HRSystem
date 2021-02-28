using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Application.Features.Emails.Commands.CreateEmail;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Emails.Queries.GetEmailByEmployee
{
    public class GetEmailsByEmployeeQueryHandler : IRequestHandler<GetEmailsByEmployeeQuery, GetEmailsByEmployeeQueryResponse>
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IEmailTypeRepository _emailTypeRepository;
        private readonly IMapper _mapper;

        public GetEmailsByEmployeeQueryHandler(IMapper mapper, 
                                            IEmailRepository emailRepository, 
                                            IEmailTypeRepository emailTypeRepository)
        {
            _mapper = mapper;
            _emailRepository = emailRepository;
            _emailTypeRepository = emailTypeRepository;
        }

        public async Task<GetEmailsByEmployeeQueryResponse> Handle(GetEmailsByEmployeeQuery request, CancellationToken cancellationToken)
        {
            var response = new GetEmailsByEmployeeQueryResponse();
            var emails = await _emailRepository.GetAllByEmployee(request.EmployeeID);
            var emailVm = _mapper.Map<ICollection<GetEmailsByEmployeeVm>>(emails);

            if (emails == null) {
                response.Success = false;
                response.Emails = null;
                return response;
            }          

            response.Emails = emailVm;
            return response;
        }
    }
}
