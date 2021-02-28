using MediatR;

namespace HRSystem.Application.Features.Positions.Commands.UpdatePosition
{
    public class UpdatePositionCommand : IRequest<UpdatePositionCommandResponse>
    {
        public int PositionID { get; set; }
        public string Name { get; set; }
    }
}
