using HRSystem.Application.Common;
using HRSystem.Application.Features.Employees.Commands.CreateEmployee;
using HRSystem.Application.Features.Employees.Commands.DeleteEmployee;
using HRSystem.Application.Features.Employees.Commands.UpdateEmployee;
using HRSystem.Application.Features.Employees.Commands.UploadEmployeePhoto;
using HRSystem.Application.Features.Employees.Queries.GetEmployee;
using HRSystem.Application.Features.Employees.Queries.GetEmployees;
using HRSystem.Domain.HR;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;


        public EmployeesController(IMediator mediator,
                                   IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Employee>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var getEmployeesCommand = new GetEmployeesQuery() { queryParameters = queryParameters };
            var response = await _mediator.Send(getEmployeesCommand);

            return Ok(response);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {

            var getEmployeeCommand = new GetEmployeeQuery() { EmployeeID = id };
            var response = await _mediator.Send(getEmployeeCommand);

            return Ok(response);

        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(CreateEmployeeCommand createEmployeeCommand)
        {
            var response = await _mediator.Send(createEmployeeCommand);

            return Ok(response.Employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, UpdateEmployeeCommand updateEmployeeCommand)
        {
            updateEmployeeCommand.EmployeeID = id;
            var response = await _mediator.Send(updateEmployeeCommand);

            return Ok(response.Employee);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand() { EmployeeID = id };

            var response = await _mediator.Send(deleteEmployeeCommand);

            return Ok(response.Employee);
        }


        // POST api/<UploadPhotosController>
        [HttpPost("UploadPhoto/{employeeID}")]
        public async Task<ActionResult> UploadPhoto(int employeeID, IFormFile file)
        {
            var uploadEmployeePhotoCommand = new UploadEmployeePhotoCommand();

            uploadEmployeePhotoCommand.Stream = file.OpenReadStream();

            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            uploadEmployeePhotoCommand.FileExtension = Path.GetExtension(fileName);
            uploadEmployeePhotoCommand.EmployeeID = employeeID;
            uploadEmployeePhotoCommand.PathToSave = _configuration.GetSection("Resources:Photos").Value;

            var response = await _mediator.Send(uploadEmployeePhotoCommand);

            return Ok();
        }
    }
}