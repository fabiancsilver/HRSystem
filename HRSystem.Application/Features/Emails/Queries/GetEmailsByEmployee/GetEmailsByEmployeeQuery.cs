using HRSystem.Application.Features.Emails.Commands.CreateEmail;
using MediatR;

namespace HRSystem.Application.Features.Emails.Queries.GetEmailByEmployee
{
    public class GetEmailsByEmployeeQuery : IRequest<GetEmailsByEmployeeQueryResponse>
    {
        public int EmployeeID { get; set; }
    }
}
