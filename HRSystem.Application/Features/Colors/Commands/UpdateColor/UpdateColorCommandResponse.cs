using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Colors.Commands.UpdateColor
{
    public class UpdateColorCommandResponse : BaseResponse
    {
        public UpdateColorCommandResponse() : base()
        {

        }

        public UpdateColorDto Color { get; set; }
    }
}