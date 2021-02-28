using HRSystem.Application.Common;
using HRSystem.Application.Features.Departments.Commands.CreateDepartment;
using HRSystem.Application.Features.Departments.Commands.DeleteDepartment;
using HRSystem.Application.Features.Departments.Commands.UpdateDepartment;
using HRSystem.Application.Features.Departments.Queries.GetDepartment;
using HRSystem.Application.Features.GetDepartments.Queries.GetDepartments;
using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Department>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getDepartmentsQuery = new GetDepartmentsQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getDepartmentsQuery);

            return Ok(response);
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> Get(int id)
        {
            var getDepartmentCommand = new GetDepartmentQuery() { DepartmentID = id };
            var response = await _mediator.Send(getDepartmentCommand);

            return Ok(response);
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task<ActionResult<Department>> Post(CreateDepartmentCommand createDepartmentCommand)
        {
            var response = await _mediator.Send(createDepartmentCommand);

            return Ok(response.Department);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> Put(int id, UpdateDepartmentCommand updateDepartmentCommand)
        {
            updateDepartmentCommand.DepartmentID = id;
            var response = await _mediator.Send(updateDepartmentCommand);

            return Ok(response.Department);
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteDepartmentCommand = new DeleteDepartmentCommand() { DepartmentID = id };

            var response = await _mediator.Send(deleteDepartmentCommand);

            return Ok(response.Department);
        }
    }
}