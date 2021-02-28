using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Shifts.Commands.CreateShift
{
    public class CreateShiftCommandHandler : IRequestHandler<CreateShiftCommand, CreateShiftCommandResponse>
    {
        private readonly IHRAsyncRepository<Shift> _shiftRepository;
        private readonly IMapper _mapper;

        public CreateShiftCommandHandler(IMapper mapper, IHRAsyncRepository<Shift> shiftRepository)
        {
            _mapper = mapper;
            _shiftRepository = shiftRepository;
        }

        public async Task<CreateShiftCommandResponse> Handle(CreateShiftCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateShiftCommandResponse();

            var validator = new CreateShiftCommandValidator();
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
                var shift = _mapper.Map<Shift>(request);
                _shiftRepository.Create(shift);
                await _shiftRepository.SaveChanges();

                response.Shift = _mapper.Map<CreateShiftDto>(shift);
            }

            return response;
        }
    }
}
