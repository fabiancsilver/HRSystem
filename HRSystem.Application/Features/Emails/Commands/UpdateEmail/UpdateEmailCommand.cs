using MediatR;

namespace HRSystem.Application.Features.Emails.Commands.UpdateEmail
{
    public class UpdateEmailCommand : IRequest<UpdateEmailCommandResponse>
    {
        public int EmailID { get; set; }

        public int EmployeeID { get; set; }

        public int EmailTypeID { get; set; }

        public string EmailAddress { get; set; }
    }
}
