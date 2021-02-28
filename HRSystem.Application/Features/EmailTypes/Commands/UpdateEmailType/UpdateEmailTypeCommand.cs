using MediatR;

namespace HRSystem.Application.Features.EmailTypes.Commands.UpdateEmailType
{
    public class UpdateEmailTypeCommand : IRequest<UpdateEmailTypeCommandResponse>
    {
        public int EmailTypeID { get; set; }
        public string Name { get; set; }
    }
}
