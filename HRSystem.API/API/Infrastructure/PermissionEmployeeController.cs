using HRSystem.Application.Features.Notifications.Queries.GetNotifications;
using HRSystem.Domain.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionEmployeeController : ControllerBase
    {

        private readonly ILogger<PermissionEmployeeController> _logger;
        //private readonly IPermissionEmployeeRepository _permissionEmployeeRepository;
        private readonly IMediator _mediator;

        public PermissionEmployeeController(ILogger<PermissionEmployeeController> logger,
                                            IMediator mediator)
        {
            _logger = logger;
            //IPermissionEmployeeRepository permissionEmployeeRepository
            //_permissionEmployeeRepository = permissionEmployeeRepository;
            _mediator = mediator;
        }

        // GET: api/<PermissionEmployeeController>/PermissionsByEmployee
        [HttpGet("ByEmployee/{employeeID}")]
        public async Task<ActionResult<ICollection<PermissionEmployee>>> ByEmployee(int employeeID)
        {
            try
            {
                var getPermissionEmployeesQuery = new GetPermissionEmployeesQuery() { EmployeeID = employeeID };
                var response = await _mediator.Send(getPermissionEmployeesQuery);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/<PermissionEmployeeController>
        [HttpGet]
        public async Task<ActionResult<ICollection<PermissionEmployee>>> Get()
        {
            try
            {
                var getPermissionEmployeesQuery = new GetPermissionEmployeesQuery() { EmployeeID = 1 };
                var response = await _mediator.Send(getPermissionEmployeesQuery);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}