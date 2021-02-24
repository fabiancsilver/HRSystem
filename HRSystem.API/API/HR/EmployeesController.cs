using HRSystem.Application.Common;

using HRSystem.Application.Repositories;
using HRSystem.Domain.HR;
using HRSystem.Persistence.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HRSystem.API.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogEmployeeRepository _logEmployeeRepository;
        private readonly ILogger<EmployeesController> _logger;
        private readonly NotificationService _notificationService;

        public EmployeesController(IEmployeeRepository employeeRepository,
                                   ILogEmployeeRepository logEmployeeRepository,
                                   ILogger<EmployeesController> logger, 
                                   NotificationService notificationService)
        {
            _employeeRepository = employeeRepository;
            _logEmployeeRepository = logEmployeeRepository;
            _logger = logger;
            _notificationService = notificationService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var employees = await _employeeRepository.GetAll(queryParameters);
                _logger.LogInformation($"Returned all item from repository.");

                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _employeeRepository.GetById(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            _employeeRepository.Create(employee);            

            if (await _employeeRepository.SaveChanges() > 0)
            {
                await _logEmployeeRepository.Log(employee);
                await _employeeRepository.SaveChanges();

                //Send Notification
                _notificationService.SendNotificaion("EMPLOYEE_ADDED");
            }

            return Ok(employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee employee)
        {
            _employeeRepository.Update(id, employee);

            if (await _employeeRepository.SaveChanges() > 0)
            {
                await _logEmployeeRepository.Log(employee);
                await _employeeRepository.SaveChanges();

                //Send Notification
                _notificationService.SendNotificaion("EMPLOYEE_MODIFIED");
            }

            return Ok();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var employee = await _employeeRepository.GetById(id);

            if (employee != null)
            {
                await _logEmployeeRepository.Log(employee);
                await _employeeRepository.SaveChanges();

                //Send Notification
                _notificationService.SendNotificaion("EMPLOYEE_DELETED");
            }

            await _employeeRepository.Remove(id);
            await _employeeRepository.SaveChanges();

            return Ok();
        }
    }
}