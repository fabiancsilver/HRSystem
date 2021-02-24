using HRSystem.Domain.HR;
using HRSystem.Domain.Report;
using HRSystem.Persistence.HR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.Infrastructure
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly ILogger<ReportsController> _logger;
        private readonly HRContext _hrContext;

        public ReportsController(ILogger<ReportsController> logger,
                                 HRContext hrContext)
        {
            _logger = logger;
            this._hrContext = hrContext;
        }

        // GET: api/<ReportsController>/WeeklyHireNumbers
        [HttpGet("WeeklyHireNumbers")]
        public async Task<ActionResult<ICollection<WeeklyHireNumber>>> WeeklyHireNumbers()
        {
            try
            {
                var report = await this._hrContext.WeeklyHireNumbers
                                                  .ToListAsync();

                return Ok(report);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/<ReportsController>/TerminatedNumbers
        [HttpGet("TerminatedNumbers")]
        public async Task<ActionResult<ICollection<TerminatedNumber>>> TerminatedNumbers()
        {
            try
            {
                var report = await this._hrContext.TerminatedNumbers.ToListAsync();

                return Ok(report);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/<ReportsController>/NumberOfEmployeeDepartments
        [HttpGet("NumberOfEmployeeDepartments")]
        public async Task<ActionResult<ICollection<NumberOfEmployeeDepartment>>> NumberOfEmployeeDepartments()
        {
            try
            {
                var report = await this._hrContext.NumberOfEmployeeDepartments.ToListAsync();

                return Ok(report);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/<ReportsController>/NumberOfEmployeeManagers
        [HttpGet("NumberOfEmployeeManagers")]
        public async Task<ActionResult<ICollection<Shift>>> NumberOfEmployeeManagers()
        {
            try
            {
                var report = await this._hrContext.NumberOfEmployeeManagers.ToListAsync();

                return Ok(report);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        // GET: api/<ReportsController>/RetentionRate
        [HttpGet("RetentionRate")]
        public async Task<ActionResult<RetentionRate>> RetationRate()
        {
            try
            {
                var report = await this._hrContext.RetentionRate.FirstOrDefaultAsync();

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