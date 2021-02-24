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
    public class EmailTypesController : ControllerBase
    {
        private readonly IEmailTypeRepository _emailTypeRepository;
        private readonly ILogger<EmailTypesController> _logger;

        public EmailTypesController(IEmailTypeRepository emailTypeRepository,
                                ILogger<EmailTypesController> logger)
        {
            _emailTypeRepository = emailTypeRepository;
            _logger = logger;
        }

        // GET: api/<EmailTypesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<EmailType>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var emailTypes = await _emailTypeRepository.GetAll(queryParameters);


                return Ok(emailTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<EmailTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailType>> Get(int id)
        {
            try
            {
                var emailType = await _emailTypeRepository.GetById(id);

                return Ok(emailType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        // POST api/<EmailTypesController>
        [HttpPost]
        public async Task<ActionResult<EmailType>> Post(EmailType emailType)
        {
            try
            {
                _emailTypeRepository.Create(emailType);
                await _emailTypeRepository.SaveChanges();

                return Ok(emailType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<EmailTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EmailType>> Put(int id, EmailType emailType)
        {
            try
            {
                _emailTypeRepository.Update(id, emailType);
                await _emailTypeRepository.SaveChanges();

                return Ok(emailType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<EmailTypesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _emailTypeRepository.Remove(id);
                await _emailTypeRepository.SaveChanges();

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