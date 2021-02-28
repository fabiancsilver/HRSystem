using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Positions.Commands.UpdatePosition
{
    public class UpdatePositionCommandResponse : BaseResponse
    {
        public UpdatePositionCommandResponse() : base()
        {

        }

        public UpdatePositionDto Position { get; set; }
    }
}