using HRSystem.Application.Features.Phones.Commands.CreatePhone;
using HRSystem.Application.Features.Phones.Commands.UpdatePhone;
using HRSystem.Application.Features.Phones.Queries.GetPhoneByEmployee;
using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhonesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<PhonesController>/5
        [HttpGet("AllByEmployee/{employeeID}")]
        public async Task<ActionResult<Phone>> GetAllByEmployee(int employeeID)
        {
            var getPhonesByEmployeeQuery = new GetPhonesByEmployeeQuery() { EmployeeID = employeeID };
            var response = await _mediator.Send(getPhonesByEmployeeQuery);

            if (response.Success == true)
            {
                return Ok(response.Phones);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<PhonesController>
        [HttpPost]
        public async Task<ActionResult<Phone>> Post(CreatePhoneCommand createPhoneCommand)
        {
            var response = await _mediator.Send(createPhoneCommand);

            return Ok(response.Phone);
        }

        // PUT api/<PhonesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Phone>> Put(int id, UpdatePhoneCommand updatePhoneCommand)
        {
            updatePhoneCommand.PhoneID = id;
            var response = await _mediator.Send(updatePhoneCommand);

            return Ok(response.Phone);
        }
    }
}