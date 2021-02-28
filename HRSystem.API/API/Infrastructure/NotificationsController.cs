using HRSystem.Application.Common;
using HRSystem.Application.Features.Notifications.Commands.CreateNotification;
using HRSystem.Application.Features.Notifications.Commands.DeleteNotification;
using HRSystem.Application.Features.Notifications.Commands.UpdateNotification;
using HRSystem.Application.Features.Notifications.Queries.GetNotification;
using HRSystem.Application.Features.Notifications.Queries.GetNotifications;

using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<NotificationsController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Notification>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getNotificationsCommand = new GetNotificationsQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getNotificationsCommand);

            return Ok(response);
        }

        // GET api/<NotificationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> Get(int id)
        {

            var getNotificationCommand = new GetNotificationQuery() { NotificationID = id };
            var response = await _mediator.Send(getNotificationCommand);

            return Ok(response);

        }

        // POST api/<NotificationsController>
        [HttpPost]
        public async Task<ActionResult<Notification>> Post(CreateNotificationCommand createNotificationCommand)
        {
            var response = await _mediator.Send(createNotificationCommand);

            return Ok(response.Notification);
        }

        // PUT api/<NotificationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Notification>> Put(int id, UpdateNotificationCommand updateNotificationCommand)
        {
            updateNotificationCommand.NotificationID = id;
            var response = await _mediator.Send(updateNotificationCommand);

            return Ok(response.Notification);
        }

        // DELETE api/<NotificationsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteNotificationCommand = new DeleteNotificationCommand() { NotificationID = id };

            var response = await _mediator.Send(deleteNotificationCommand);

            return Ok(response.Notification);
        }
    }
}