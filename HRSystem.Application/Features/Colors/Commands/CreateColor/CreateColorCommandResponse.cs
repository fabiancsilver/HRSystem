using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Colors.Commands.CreateColor
{
    public class CreateColorCommandResponse : BaseResponse
    {
        public CreateColorCommandResponse() : base()
        {

        }

        public CreateColorDto Color { get; set; }
    }
}