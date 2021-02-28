using HRSystem.Application.Common;
using HRSystem.Application.Features.Positions.Commands.CreatePosition;
using HRSystem.Application.Features.Positions.Commands.DeletePosition;
using HRSystem.Application.Features.Positions.Commands.UpdatePosition;
using HRSystem.Application.Features.Positions.Queries.GetPosition;
using HRSystem.Application.Features.Positions.Queries.GetPositions;
using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PositionsController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Position>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getPositionsCommand = new GetPositionsQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getPositionsCommand);

            return Ok(response);
        }

        // GET api/<PositionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> Get(int id)
        {

            var getPositionCommand = new GetPositionQuery() { PositionID = id };
            var response = await _mediator.Send(getPositionCommand);

            return Ok(response);

        }

        // POST api/<PositionsController>
        [HttpPost]
        public async Task<ActionResult<Position>> Post(CreatePositionCommand createPositionCommand)
        {
            var response = await _mediator.Send(createPositionCommand);

            return Ok(response.Position);
        }

        // PUT api/<PositionsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Position>> Put(int id, UpdatePositionCommand updatePositionCommand)
        {
            updatePositionCommand.PositionID = id;
            var response = await _mediator.Send(updatePositionCommand);

            return Ok(response.Position);
        }

        // DELETE api/<PositionsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletePositionCommand = new DeletePositionCommand() { PositionID = id };

            var response = await _mediator.Send(deletePositionCommand);

            return Ok(response.Position);
        }
    }
}