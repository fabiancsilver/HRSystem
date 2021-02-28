using HRSystem.Application.Features.Emails.Commands.CreateEmail;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Emails.Queries.GetEmailByEmployee
{
    public class GetEmailsByEmployeeQuery : IRequest<GetEmailsByEmployeeQueryResponse>
    {
        public int EmployeeID { get; set; }
    }
}
