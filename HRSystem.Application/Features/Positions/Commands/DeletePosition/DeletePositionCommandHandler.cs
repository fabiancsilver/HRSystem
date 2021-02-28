using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Positions.Commands.DeletePosition
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, DeletePositionCommandResponse>
    {
        private readonly IHRAsyncRepository<Position> _positionRepository;
        private readonly IMapper _mapper;

        public DeletePositionCommandHandler(IMapper mapper, IHRAsyncRepository<Position> positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<DeletePositionCommandResponse> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var response = new DeletePositionCommandResponse();

            var validator = new DeletePositionCommandValidator();
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
                await _positionRepository.Remove(position.PositionID);
                await _positionRepository.SaveChanges();

                response.Position = _mapper.Map<DeletePositionDto>(position);
            }

            return response;
        }
    }
}
