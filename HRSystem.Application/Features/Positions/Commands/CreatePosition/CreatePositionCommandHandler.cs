using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, CreatePositionCommandResponse>
    {
        private readonly IHRAsyncRepository<Position> _positionRepository;
        private readonly IMapper _mapper;

        public CreatePositionCommandHandler(IMapper mapper, IHRAsyncRepository<Position> positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<CreatePositionCommandResponse> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var response = new CreatePositionCommandResponse();

            var validator = new CreatePositionCommandValidator();
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
                var position = _mapper.Map<Position>(request);
                _positionRepository.Create(position);
                await _positionRepository.SaveChanges();

                response.Position = _mapper.Map<CreatePositionDto>(position);
            }

            return response;
        }
    }
}
