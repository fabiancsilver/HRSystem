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
    public class StatusesController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly ILogger<StatusesController> _logger;

        public StatusesController(IStatusRepository statusRepository,
                                ILogger<StatusesController> logger)
        {
            _statusRepository = statusRepository;
            _logger = logger;
        }

        // GET: api/<StatusesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Status>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var statuss = await _statusRepository.GetAll(queryParameters);


                return Ok(statuss);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<StatusesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> Get(int id)
        {
            try
            {
                var status = await _statusRepository.GetById(id);

                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        // POST api/<StatusesController>
        [HttpPost]
        public async Task<ActionResult<Status>> Post(Status status)
        {
            try
            {
                _statusRepository.Create(status);
                await _statusRepository.SaveChanges();

                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<StatusesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Status>> Put(int id, Status status)
        {
            try
            {
                _statusRepository.Update(id, status);
                await _statusRepository.SaveChanges();

                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<StatusesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _statusRepository.Remove(id);
                await _statusRepository.SaveChanges();

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