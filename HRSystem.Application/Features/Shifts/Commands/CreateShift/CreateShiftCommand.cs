using MediatR;

namespace HRSystem.Application.Features.Shifts.Commands.CreateShift
{
    public class CreateShiftCommand : IRequest<CreateShiftCommandResponse>
    {
        public string Name { get; set; }
    }
}
