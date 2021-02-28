using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand, UpdateStatusCommandResponse>
    {
        private readonly IHRAsyncRepository<Status> _statusRepository;
        private readonly IMapper _mapper;

        public UpdateStatusCommandHandler(IMapper mapper, IHRAsyncRepository<Status> statusRepository)
        {
            _mapper = mapper;
            _statusRepository = statusRepository;
        }

        public async Task<UpdateStatusCommandResponse> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateStatusCommandResponse();

            var validator = new UpdateStatusCommandValidator();
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
                var status = _mapper.Map<Status>(request);
                _statusRepository.Update(status.StatusID, status);
                await _statusRepository.SaveChanges();

                response.Status = _mapper.Map<UpdateStatusDto>(status);
            }

            return response;
        }
    }
}
