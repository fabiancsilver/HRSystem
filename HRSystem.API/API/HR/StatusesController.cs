using HRSystem.Application.Common;
using HRSystem.Application.Features.Statuses.Commands.CreateStatus;
using HRSystem.Application.Features.Statuses.Commands.DeleteStatus;
using HRSystem.Application.Features.Statuses.Commands.UpdateStatus;
using HRSystem.Application.Features.Statuses.Queries.GetStatus;
using HRSystem.Application.Features.Statuses.Queries.GetStatuses;

using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatusesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<StatusesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Status>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getStatusesCommand = new GetStatusesQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getStatusesCommand);

            return Ok(response);
        }

        // GET api/<StatusesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> Get(int id)
        {

            var getStatusCommand = new GetStatusQuery() { StatusID = id };
            var response = await _mediator.Send(getStatusCommand);

            return Ok(response);

        }

        // POST api/<StatusesController>
        [HttpPost]
        public async Task<ActionResult<Status>> Post(CreateStatusCommand createStatusCommand)
        {
            var response = await _mediator.Send(createStatusCommand);

            return Ok(response.Status);
        }

        // PUT api/<StatusesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Status>> Put(int id, UpdateStatusCommand updateStatusCommand)
        {
            updateStatusCommand.StatusID = id;
            var response = await _mediator.Send(updateStatusCommand);

            return Ok(response.Status);
        }

        // DELETE api/<StatusesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteStatusCommand = new DeleteStatusCommand() { StatusID = id };

            var response = await _mediator.Send(deleteStatusCommand);

            return Ok(response.Status);
        }
    }
}