using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Colors.Commands.DeleteColor
{
    public class DeleteColorCommandResponse : BaseResponse
    {
        public DeleteColorCommandResponse() : base()
        {

        }

        public DeleteColorDto Color { get; set; }
    }
}