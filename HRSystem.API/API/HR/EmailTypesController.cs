using HRSystem.Application.Common;
using HRSystem.Application.Features.EmailTypes.Commands.CreateEmailType;
using HRSystem.Application.Features.EmailTypes.Commands.DeleteEmailType;
using HRSystem.Application.Features.EmailTypes.Commands.UpdateEmailType;
using HRSystem.Application.Features.EmailTypes.Queries.GetEmailType;
using HRSystem.Application.Features.EmailTypes.Queries.GetEmailTypes;

using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EmailTypesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<EmailType>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getEmailTypesCommand = new GetEmailTypesQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getEmailTypesCommand);

            return Ok(response);
        }

        // GET api/<EmailTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailType>> Get(int id)
        {

            var getEmailTypeCommand = new GetEmailTypeQuery() { EmailTypeID = id };
            var response = await _mediator.Send(getEmailTypeCommand);

            return Ok(response);

        }

        // POST api/<EmailTypesController>
        [HttpPost]
        public async Task<ActionResult<EmailType>> Post(CreateEmailTypeCommand createEmailTypeCommand)
        {
            var response = await _mediator.Send(createEmailTypeCommand);

            return Ok(response.EmailType);
        }

        // PUT api/<EmailTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EmailType>> Put(int id, UpdateEmailTypeCommand updateEmailTypeCommand)
        {
            updateEmailTypeCommand.EmailTypeID = id;
            var response = await _mediator.Send(updateEmailTypeCommand);

            return Ok(response.EmailType);
        }

        // DELETE api/<EmailTypesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteEmailTypeCommand = new DeleteEmailTypeCommand() { EmailTypeID = id };

            var response = await _mediator.Send(deleteEmailTypeCommand);

            return Ok(response.EmailType);
        }
    }
}