using HRSystem.Application.Features.Emails.Commands.CreateEmail;
using HRSystem.Application.Features.Emails.Commands.UpdateEmail;
using HRSystem.Application.Features.Emails.Queries.GetEmailByEmployee;
using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<EmailsController>/5
        [HttpGet("AllByEmployee/{employeeID}")]
        public async Task<ActionResult<Email>> GetAllByEmployee(int employeeID)
        {
            var getEmailsByEmployeeQuery = new GetEmailsByEmployeeQuery() { EmployeeID = employeeID };
            var response = await _mediator.Send(getEmailsByEmployeeQuery);

            if (response.Success == true)
            {
                return Ok(response.Emails);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<EmailsController>
        [HttpPost]
        public async Task<ActionResult<Email>> Post(CreateEmailCommand createEmailCommand)
        {
            var response = await _mediator.Send(createEmailCommand);

            return Ok(response.Email);
        }

        // PUT api/<EmailsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Email>> Put(int id, UpdateEmailCommand updateEmailCommand)
        {
            updateEmailCommand.EmailID = id;
            var response = await _mediator.Send(updateEmailCommand);

            return Ok(response.Email);
        }
    }
}