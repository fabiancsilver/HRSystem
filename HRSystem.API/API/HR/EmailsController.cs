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
    public class EmailsController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;
        private readonly ILogger<EmailsController> _logger;

        public EmailsController(IEmailRepository emailRepository,
                                ILogger<EmailsController> logger)
        {
            _emailRepository = emailRepository;
            _logger = logger;
        }

        // GET: api/<EmailsController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Email>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var emails = await _emailRepository.GetAll(queryParameters);


                return Ok(emails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/<EmailsController>/ByEmployee
        [HttpGet("AllByEmployee/{employeeID}")]
        public async Task<ActionResult<ICollection<Email>>> GetAllByEmployee(Int32 employeeID)
        {
            try
            {
                var emails = await _emailRepository.GetAllByEmployee(employeeID);

                return Ok(emails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<EmailsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Email>> Get(int id)
        {
            try
            {
                var email = await _emailRepository.GetById(id);

                return Ok(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<EmailsController>
        [HttpPost]
        public async Task<ActionResult<Email>> Post(Email email)
        {
            try
            {
                _emailRepository.Create(email);
                await _emailRepository.SaveChanges();

                return Ok(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<EmailsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Email>> Put(int id, Email email)
        {
            try
            {
                _emailRepository.Update(id, email);
                await _emailRepository.SaveChanges();

                return Ok(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<EmailsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _emailRepository.Remove(id);
                await _emailRepository.SaveChanges();

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