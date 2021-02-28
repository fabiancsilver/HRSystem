using MediatR;

namespace HRSystem.Application.Features.Positions.Commands.DeletePosition
{
    public class DeletePositionCommand : IRequest<DeletePositionCommandResponse>
    {
        public int PositionID { get; set; }
    }
}
