using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Statuses.Commands.DeleteStatus
{
    public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand, DeleteStatusCommandResponse>
    {
        private readonly IHRAsyncRepository<Status> _statusRepository;
        private readonly IMapper _mapper;

        public DeleteStatusCommandHandler(IMapper mapper, IHRAsyncRepository<Status> statusRepository)
        {
            _mapper = mapper;
            _statusRepository = statusRepository;
        }

        public async Task<DeleteStatusCommandResponse> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteStatusCommandResponse();

            var validator = new DeleteStatusCommandValidator();
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
                await _statusRepository.Remove(status.StatusID);
                await _statusRepository.SaveChanges();

                response.Status = _mapper.Map<DeleteStatusDto>(status);
            }

            return response;
        }
    }
}
