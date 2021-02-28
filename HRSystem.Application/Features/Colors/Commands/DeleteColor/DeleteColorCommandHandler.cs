using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Colors.Commands.DeleteColor
{
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeleteColorCommandResponse>
    {
        private readonly IHRAsyncRepository<Color> _colorRepository;
        private readonly IMapper _mapper;

        public DeleteColorCommandHandler(IMapper mapper, IHRAsyncRepository<Color> colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<DeleteColorCommandResponse> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteColorCommandResponse();

            var validator = new DeleteColorCommandValidator();
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
                await _colorRepository.Remove(color.ColorID);
                await _colorRepository.SaveChanges();

                response.Color = _mapper.Map<DeleteColorDto>(color);
            }

            return response;
        }
    }
}
