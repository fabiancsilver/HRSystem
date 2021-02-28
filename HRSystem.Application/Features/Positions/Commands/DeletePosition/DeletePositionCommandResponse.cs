using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Positions.Commands.DeletePosition
{
    public class DeletePositionCommandResponse : BaseResponse
    {
        public DeletePositionCommandResponse() : base()
        {

        }

        public DeletePositionDto Position { get; set; }
    }
}