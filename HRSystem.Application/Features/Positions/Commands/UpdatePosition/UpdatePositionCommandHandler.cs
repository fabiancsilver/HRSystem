using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Positions.Commands.UpdatePosition
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, UpdatePositionCommandResponse>
    {
        private readonly IHRAsyncRepository<Position> _positionRepository;
        private readonly IMapper _mapper;

        public UpdatePositionCommandHandler(IMapper mapper, IHRAsyncRepository<Position> positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<UpdatePositionCommandResponse> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdatePositionCommandResponse();

            var validator = new UpdatePositionCommandValidator();
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
                _positionRepository.Update(position.PositionID, position);
                await _positionRepository.SaveChanges();

                response.Position = _mapper.Map<UpdatePositionDto>(position);
            }

            return response;
        }
    }
}
