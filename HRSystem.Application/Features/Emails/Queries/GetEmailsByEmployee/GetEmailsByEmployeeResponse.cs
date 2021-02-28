using HRSystem.Application.Features.Emails.Queries.GetEmailByEmployee;
using HRSystem.Application.Responses;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Emails.Commands.CreateEmail
{
    public class GetEmailsByEmployeeQueryResponse : BaseResponse
    {
        public GetEmailsByEmployeeQueryResponse() : base()
        {

        }

        public ICollection<GetEmailsByEmployeeVm> Emails { get; set; }
    }
}