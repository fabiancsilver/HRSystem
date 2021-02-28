using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Shifts.Commands.UpdateShift
{
    public class UpdateShiftCommandHandler : IRequestHandler<UpdateShiftCommand, UpdateShiftCommandResponse>
    {
        private readonly IHRAsyncRepository<Shift> _shiftRepository;
        private readonly IMapper _mapper;

        public UpdateShiftCommandHandler(IMapper mapper, IHRAsyncRepository<Shift> shiftRepository)
        {
            _mapper = mapper;
            _shiftRepository = shiftRepository;
        }

        public async Task<UpdateShiftCommandResponse> Handle(UpdateShiftCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateShiftCommandResponse();

            var validator = new UpdateShiftCommandValidator();
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
                _shiftRepository.Update(shift.ShiftID, shift);
                await _shiftRepository.SaveChanges();

                response.Shift = _mapper.Map<UpdateShiftDto>(shift);
            }

            return response;
        }
    }
}
