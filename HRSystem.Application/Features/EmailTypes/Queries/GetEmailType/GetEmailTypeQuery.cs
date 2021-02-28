using MediatR;
using System;

namespace HRSystem.Application.Features.EmailTypes.Queries.GetEmailType
{
    public class GetEmailTypeQuery : IRequest<GetEmailTypeVm>
    {
        public int EmailTypeID { get; set; }
    }
}
