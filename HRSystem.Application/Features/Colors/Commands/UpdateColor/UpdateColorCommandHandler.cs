using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Colors.Commands.UpdateColor
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, UpdateColorCommandResponse>
    {
        private readonly IHRAsyncRepository<Color> _colorRepository;
        private readonly IMapper _mapper;

        public UpdateColorCommandHandler(IMapper mapper, IHRAsyncRepository<Color> colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<UpdateColorCommandResponse> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateColorCommandResponse();

            var validator = new UpdateColorCommandValidator();
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
                var color = _mapper.Map<Color>(request);
                _colorRepository.Update(color.ColorID, color);
                await _colorRepository.SaveChanges();

                response.Color = _mapper.Map<UpdateColorDto>(color);
            }

            return response;
        }
    }
}
