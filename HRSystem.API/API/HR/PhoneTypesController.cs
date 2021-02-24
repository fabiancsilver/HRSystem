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
    public class PhoneTypesController : ControllerBase
    {
        private readonly IPhoneTypeRepository _phoneTypeRepository;
        private readonly ILogger<PhoneTypesController> _logger;

        public PhoneTypesController(IPhoneTypeRepository phoneTypeRepository,
                                ILogger<PhoneTypesController> logger)
        {
            _phoneTypeRepository = phoneTypeRepository;
            _logger = logger;
        }

        // GET: api/<PhoneTypesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<PhoneType>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var phoneTypes = await _phoneTypeRepository.GetAll(queryParameters);


                return Ok(phoneTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<PhoneTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneType>> Get(int id)
        {
            try
            {
                var phoneType = await _phoneTypeRepository.GetById(id);

                return Ok(phoneType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        // POST api/<PhoneTypesController>
        [HttpPost]
        public async Task<ActionResult<PhoneType>> Post(PhoneType phoneType)
        {
            try
            {
                _phoneTypeRepository.Create(phoneType);
                await _phoneTypeRepository.SaveChanges();

                return Ok(phoneType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<PhoneTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PhoneType>> Put(int id, PhoneType phoneType)
        {
            try
            {
                _phoneTypeRepository.Update(id, phoneType);
                await _phoneTypeRepository.SaveChanges();

                return Ok(phoneType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<PhoneTypesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _phoneTypeRepository.Remove(id);
                await _phoneTypeRepository.SaveChanges();

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