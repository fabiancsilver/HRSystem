using HRSystem.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Notifications.Queries.GetNotifications
{
    public class GetNotificationsQuery : IRequest<IEnumerable<GetNotificationsVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
