using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandResponse : BaseResponse
    {
        public CreatePositionCommandResponse() : base()
        {

        }

        public CreatePositionDto Position { get; set; }
    }
}