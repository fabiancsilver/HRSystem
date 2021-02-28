using HRSystem.Application.Common;
using HRSystem.Application.Features.AddressTypes.Commands.CreateAddressType;
using HRSystem.Application.Features.AddressTypes.Commands.DeleteAddressType;
using HRSystem.Application.Features.AddressTypes.Commands.UpdateAddressType;
using HRSystem.Application.Features.AddressTypes.Queries.GetAddressType;
using HRSystem.Application.Features.AddressTypes.Queries.GetAddressTypes;

using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AddressTypesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<AddressType>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getAddressTypesCommand = new GetAddressTypesQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getAddressTypesCommand);

            return Ok(response);
        }

        // GET api/<AddressTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressType>> Get(int id)
        {

            var getAddressTypeCommand = new GetAddressTypeQuery() { AddressTypeID = id };
            var response = await _mediator.Send(getAddressTypeCommand);

            return Ok(response);

        }

        // POST api/<AddressTypesController>
        [HttpPost]
        public async Task<ActionResult<AddressType>> Post(CreateAddressTypeCommand createAddressTypeCommand)
        {
            var response = await _mediator.Send(createAddressTypeCommand);

            return Ok(response.AddressType);
        }

        // PUT api/<AddressTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AddressType>> Put(int id, UpdateAddressTypeCommand updateAddressTypeCommand)
        {
            updateAddressTypeCommand.AddressTypeID = id;
            var response = await _mediator.Send(updateAddressTypeCommand);

            return Ok(response.AddressType);
        }

        // DELETE api/<AddressTypesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteAddressTypeCommand = new DeleteAddressTypeCommand() { AddressTypeID = id };

            var response = await _mediator.Send(deleteAddressTypeCommand);

            return Ok(response.AddressType);
        }
    }
}