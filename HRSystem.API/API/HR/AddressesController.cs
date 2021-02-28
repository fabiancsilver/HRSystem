using HRSystem.Application.Features.Addresses.Commands.CreateAddress;
using HRSystem.Application.Features.Addresses.Commands.UpdateAddress;
using HRSystem.Application.Features.Addresses.Queries.GetAddressByEmployee;

using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<AddressesController>/5
        [HttpGet("ByEmployee/{employeeID}")]
        public async Task<ActionResult<Address>> GetByEmployee(int employeeID)
        {
            var getAddressByEmployeeQuery = new GetAddressByEmployeeQuery() { EmployeeID = employeeID };
            var response = await _mediator.Send(getAddressByEmployeeQuery);

            if (response.Success == true)
            {
                return Ok(response.Address);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<AddressesController>
        [HttpPost]
        public async Task<ActionResult<Address>> Post(CreateAddressCommand createAddressCommand)
        {
            var response = await _mediator.Send(createAddressCommand);

            return Ok(response.Address);
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> Put(int id, UpdateAddressCommand updateAddressCommand)
        {
            updateAddressCommand.AddressID = id;
            var response = await _mediator.Send(updateAddressCommand);

            return Ok(response.Address);
        }
    }
}