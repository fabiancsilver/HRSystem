using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Colors.Commands.CreateColor
{
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreateColorCommandResponse>
    {
        private readonly IHRAsyncRepository<Color> _colorRepository;
        private readonly IMapper _mapper;

        public CreateColorCommandHandler(IMapper mapper, IHRAsyncRepository<Color> colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<CreateColorCommandResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateColorCommandResponse();

            var validator = new CreateColorCommandValidator();
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
                _colorRepository.Create(color);
                await _colorRepository.SaveChanges();

                response.Color = _mapper.Map<CreateColorDto>(color);
            }

            return response;
        }
    }
}
