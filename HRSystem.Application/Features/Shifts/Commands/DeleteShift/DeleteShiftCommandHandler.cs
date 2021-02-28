using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Shifts.Commands.DeleteShift
{
    public class DeleteShiftCommandHandler : IRequestHandler<DeleteShiftCommand, DeleteShiftCommandResponse>
    {
        private readonly IHRAsyncRepository<Shift> _shiftRepository;
        private readonly IMapper _mapper;

        public DeleteShiftCommandHandler(IMapper mapper, IHRAsyncRepository<Shift> shiftRepository)
        {
            _mapper = mapper;
            _shiftRepository = shiftRepository;
        }

        public async Task<DeleteShiftCommandResponse> Handle(DeleteShiftCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteShiftCommandResponse();

            var validator = new DeleteShiftCommandValidator();
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
                await _shiftRepository.Remove(shift.ShiftID);
                await _shiftRepository.SaveChanges();

                response.Shift = _mapper.Map<DeleteShiftDto>(shift);
            }

            return response;
        }
    }
}
