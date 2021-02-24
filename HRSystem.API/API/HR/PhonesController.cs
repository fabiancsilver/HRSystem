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
    public class PhonesController : ControllerBase
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly ILogger<PhonesController> _logger;

        public PhonesController(IPhoneRepository phoneRepository,
                                ILogger<PhonesController> logger)
        {
            _phoneRepository = phoneRepository;
            _logger = logger;
        }

        // GET: api/<PhonesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Phone>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var phones = await _phoneRepository.GetAll(queryParameters);


                return Ok(phones);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/<PhonesController>/ByEmployee
        [HttpGet("AllByEmployee/{employeeID}")]
        public async Task<ActionResult<ICollection<Phone>>> GetAllByEmployee(Int32 employeeID)
        {
            try
            {
                var phones = await _phoneRepository.GetAllByEmployee(employeeID);

                return Ok(phones);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<PhonesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> Get(int id)
        {
            try
            {
                var phone = await _phoneRepository.GetById(id);

                return Ok(phone);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<PhonesController>/ByEmployee/5
        [HttpGet("ByEmployee/{employeeID}")]
        public async Task<ActionResult<Phone>> GetByEmployee(int employeeID)
        {
            try
            {
                var phone = await _phoneRepository.GetByEmployee(employeeID);

                return Ok(phone);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        // POST api/<PhonesController>
        [HttpPost]
        public async Task<ActionResult<Phone>> Post(Phone phone)
        {
            try
            {
                _phoneRepository.Create(phone);
                await _phoneRepository.SaveChanges();

                return Ok(phone);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<PhonesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Phone>> Put(int id, Phone phone)
        {
            try
            {
                _phoneRepository.Update(id, phone);
                await _phoneRepository.SaveChanges();

                return Ok(phone);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<PhonesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _phoneRepository.Remove(id);
                await _phoneRepository.SaveChanges();

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