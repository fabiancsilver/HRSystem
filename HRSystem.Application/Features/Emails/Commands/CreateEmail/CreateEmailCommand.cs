using MediatR;

namespace HRSystem.Application.Features.Emails.Commands.CreateEmail
{
    public class CreateEmailCommand : IRequest<CreateEmailCommandResponse>
    {

        public int EmailID { get; set; }

        public int EmployeeID { get; set; }

        public int EmailTypeID { get; set; }

        public string EmailAddress { get; set; }

    }
}
