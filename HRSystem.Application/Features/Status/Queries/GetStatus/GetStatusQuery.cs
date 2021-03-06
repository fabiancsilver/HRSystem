﻿using MediatR;

namespace HRSystem.Application.Features.Statuses.Queries.GetStatus
{
    public class GetStatusQuery : IRequest<GetStatusVm>
    {
        public int StatusID { get; set; }
    }
}
