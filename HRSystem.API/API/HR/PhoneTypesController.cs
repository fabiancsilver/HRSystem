using HRSystem.Application.Common;
using HRSystem.Application.Features.PhoneTypes.Commands.CreatePhoneType;
using HRSystem.Application.Features.PhoneTypes.Commands.DeletePhoneType;
using HRSystem.Application.Features.PhoneTypes.Commands.UpdatePhoneType;
using HRSystem.Application.Features.PhoneTypes.Queries.GetPhoneType;
using HRSystem.Application.Features.PhoneTypes.Queries.GetPhoneTypes;
using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhoneTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PhoneTypesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<PhoneType>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getPhoneTypesCommand = new GetPhoneTypesQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getPhoneTypesCommand);

            return Ok(response);
        }

        // GET api/<PhoneTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneType>> Get(int id)
        {

            var getPhoneTypeCommand = new GetPhoneTypeQuery() { PhoneTypeID = id };
            var response = await _mediator.Send(getPhoneTypeCommand);

            return Ok(response);

        }

        // POST api/<PhoneTypesController>
        [HttpPost]
        public async Task<ActionResult<PhoneType>> Post(CreatePhoneTypeCommand createPhoneTypeCommand)
        {
            var response = await _mediator.Send(createPhoneTypeCommand);

            return Ok(response.PhoneType);
        }

        // PUT api/<PhoneTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PhoneType>> Put(int id, UpdatePhoneTypeCommand updatePhoneTypeCommand)
        {
            updatePhoneTypeCommand.PhoneTypeID = id;
            var response = await _mediator.Send(updatePhoneTypeCommand);

            return Ok(response.PhoneType);
        }

        // DELETE api/<PhoneTypesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletePhoneTypeCommand = new DeletePhoneTypeCommand() { PhoneTypeID = id };

            var response = await _mediator.Send(deletePhoneTypeCommand);

            return Ok(response.PhoneType);
        }
    }
}