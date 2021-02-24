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
    public class AddressTypesController : ControllerBase
    {
        private readonly IAddressTypeRepository _addressTypeRepository;
        private readonly ILogger<AddressTypesController> _logger;

        public AddressTypesController(IAddressTypeRepository addressTypeRepository,
                                      ILogger<AddressTypesController> logger)
        {
            _addressTypeRepository = addressTypeRepository;
            _logger = logger;
        }

        // GET: api/<AddressTypesController>
        [HttpGet]
        public async Task<ActionResult<ICollection<AddressType>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var addressTypes = await _addressTypeRepository.GetAll(queryParameters);


                return Ok(addressTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<AddressTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressType>> Get(int id)
        {
            try
            {
                var addressType = await _addressTypeRepository.GetById(id);

                return Ok(addressType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        // POST api/<AddressTypesController>
        [HttpPost]
        public async Task<ActionResult<AddressType>> Post(AddressType addressType)
        {
            try
            {
                _addressTypeRepository.Create(addressType);
                await _addressTypeRepository.SaveChanges();

                return Ok(addressType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<AddressTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AddressType>> Put(int id, AddressType addressType)
        {
            try
            {
                _addressTypeRepository.Update(id, addressType);
                await _addressTypeRepository.SaveChanges();

                return Ok(addressType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<AddressTypesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _addressTypeRepository.Remove(id);
                await _addressTypeRepository.SaveChanges();

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