using HRSystem.Domain.Infrastructure;
using HRSystem.Persistence.HR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionEmployeeController : ControllerBase
    {

        private readonly ILogger<PermissionEmployeeController> _logger;
        private readonly HRContext _hrContext;

        public PermissionEmployeeController(ILogger<PermissionEmployeeController> logger,
                                            HRContext hrContext)
        {
            _logger = logger;
            this._hrContext = hrContext;
        }

        // GET: api/<PermissionEmployeeController>/PermissionsByEmployee
        [HttpGet("ByEmployee/{employeeID}")]
        public async Task<ActionResult<ICollection<PermissionEmployee>>> ByEmployee(int employeeID)
        {
            try
            {
                var report = await this._hrContext.PermissionEmployee
                                                  .Include(x => x.Permission)
                                                  .Include(x=> x.Employee)
                                                  .Where(x => x.EmployeeID == employeeID)
                                                  .ToListAsync();

                return Ok(report);
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
                var report = await this._hrContext.PermissionEmployee
                                                  .Include(x => x.Permission)
                                                  .Include(x => x.Employee)
                                                  .ToListAsync();

                return Ok(report);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}