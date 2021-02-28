using HRSystem.Application.Common;
using HRSystem.Application.Features.Colors.Commands.CreateColor;
using HRSystem.Application.Features.Colors.Commands.DeleteColor;
using HRSystem.Application.Features.Colors.Commands.UpdateColor;
using HRSystem.Application.Features.Colors.Queries.GetColor;
using HRSystem.Application.Features.Colors.Queries.GetColors;
using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ColorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ColorsController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Color>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getColorsCommand = new GetColorsQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getColorsCommand);

            return Ok(response);
        }

        // GET api/<ColorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> Get(int id)
        {

            var getColorCommand = new GetColorQuery() { ColorID = id };
            var response = await _mediator.Send(getColorCommand);

            return Ok(response);

        }

        // POST api/<ColorsController>
        [HttpPost]
        public async Task<ActionResult<Color>> Post(CreateColorCommand createColorCommand)
        {
            var response = await _mediator.Send(createColorCommand);

            return Ok(response.Color);
        }

        // PUT api/<ColorsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Color>> Put(int id, UpdateColorCommand updateColorCommand)
        {
            updateColorCommand.ColorID = id;
            var response = await _mediator.Send(updateColorCommand);

            return Ok(response.Color);
        }

        // DELETE api/<ColorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteColorCommand = new DeleteColorCommand() { ColorID = id };

            var response = await _mediator.Send(deleteColorCommand);

            return Ok(response.Color);
        }
    }
}