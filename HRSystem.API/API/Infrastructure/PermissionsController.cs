using HRSystem.Application.Common;
using HRSystem.Application.Features.Permissions.Commands.CreatePermission;
using HRSystem.Application.Features.Permissions.Commands.DeletePermission;
using HRSystem.Application.Features.Permissions.Commands.UpdatePermission;
using HRSystem.Application.Features.Permissions.Queries.GetPermission;
using HRSystem.Application.Features.Permissions.Queries.GetPermissions;
using HRSystem.Domain.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PermissionsController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Permission>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getPermissionsCommand = new GetPermissionsQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getPermissionsCommand);

            return Ok(response);
        }

        // GET api/<PermissionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> Get(int id)
        {

            var getPermissionCommand = new GetPermissionQuery() { PermissionID = id };
            var response = await _mediator.Send(getPermissionCommand);

            return Ok(response);

        }

        // POST api/<PermissionsController>
        [HttpPost]
        public async Task<ActionResult<Permission>> Post(CreatePermissionCommand createPermissionCommand)
        {
            var response = await _mediator.Send(createPermissionCommand);

            return Ok(response.Permission);
        }

        // PUT api/<PermissionsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Permission>> Put(int id, UpdatePermissionCommand updatePermissionCommand)
        {
            updatePermissionCommand.PermissionID = id;
            var response = await _mediator.Send(updatePermissionCommand);

            return Ok(response.Permission);
        }

        // DELETE api/<PermissionsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletePermissionCommand = new DeletePermissionCommand() { PermissionID = id };

            var response = await _mediator.Send(deletePermissionCommand);

            return Ok(response.Permission);
        }
    }
}