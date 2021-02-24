using HRSystem.Application.Common;
using HRSystem.Application.Repositories;
using HRSystem.Domain.HR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(IDepartmentRepository departmentRepository,
                                ILogger<DepartmentsController> logger)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
        }

        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Department>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var departments = await _departmentRepository.GetAll(queryParameters);


                return Ok(departments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> Get(int id)
        {
            try
            {
                var department = await _departmentRepository.GetById(id);

                return Ok(department);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task<ActionResult<Department>> Post(Department department)
        {
            try
            {
                _departmentRepository.Create(department);
                await _departmentRepository.SaveChanges();

                return Ok(department);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> Put(int id, Department department)
        {
            try
            {
                _departmentRepository.Update(id, department);
                await _departmentRepository.SaveChanges();

                return Ok(department);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _departmentRepository.Remove(id);
                await _departmentRepository.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}