using HRSystem.Application.Common;
using HRSystem.Application.Features.Shifts.Commands.CreateShift;
using HRSystem.Application.Features.Shifts.Commands.DeleteShift;
using HRSystem.Application.Features.Shifts.Commands.UpdateShift;
using HRSystem.Application.Features.Shifts.Queries.GetShift;
using HRSystem.Application.Features.Shifts.Queries.GetShifts;
using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShiftsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<Shift>
        [HttpGet]
        public async Task<ActionResult<ICollection<Shift>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getShiftsCommand = new GetShiftsQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getShiftsCommand);

            return Ok(response);
        }

        // GET api/<Shift>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shift>> Get(int id)
        {

            var getShiftCommand = new GetShiftQuery() { ShiftID = id };
            var response = await _mediator.Send(getShiftCommand);

            return Ok(response);

        }

        // POST api/<Shift>
        [HttpPost]
        public async Task<ActionResult<Shift>> Post(CreateShiftCommand createShiftCommand)
        {
            var response = await _mediator.Send(createShiftCommand);

            return Ok(response.Shift);
        }

        // PUT api/<Shift>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Shift>> Put(int id, UpdateShiftCommand updateShiftCommand)
        {
            updateShiftCommand.ShiftID = id;
            var response = await _mediator.Send(updateShiftCommand);

            return Ok(response.Shift);
        }

        // DELETE api/<Shift>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteShiftCommand = new DeleteShiftCommand() { ShiftID = id };

            var response = await _mediator.Send(deleteShiftCommand);

            return Ok(response.Shift);
        }
    }
}