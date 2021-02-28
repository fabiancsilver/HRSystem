using MediatR;

namespace HRSystem.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommand : IRequest<CreatePositionCommandResponse>
    {
        public string Name { get; set; }
    }
}
