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
    public class AddressesController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<AddressesController> _logger;

        public AddressesController(IAddressRepository addressRepository,
                                    ILogger<AddressesController> logger)
        {
            _addressRepository = addressRepository;
            _logger = logger;
        }

        // GET: api/<AddresssController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Address>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var addresss = await _addressRepository.GetAll(queryParameters);


                return Ok(addresss);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<AddresssController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(int id)
        {
            try
            {
                var address = await _addressRepository.GetById(id);

                return Ok(address);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<AddresssController>/5
        [HttpGet("ByEmployee/{employeeID}")]
        public async Task<ActionResult<Address>> GetByEmployee(int employeeID)
        {
            try
            {
                var address = await _addressRepository.GetByEmployee(employeeID);

                return Ok(address);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<AddresssController>
        [HttpPost]
        public async Task<ActionResult<Address>> Post(Address address)
        {
            try
            {
                _addressRepository.Create(address);
                await _addressRepository.SaveChanges();

                return Ok(address);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<AddresssController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> Put(int id, Address address)
        {
            try
            {
                _addressRepository.Update(id, address);
                await _addressRepository.SaveChanges();

                return Ok(address);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<AddresssController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _addressRepository.Remove(id);
                await _addressRepository.SaveChanges();

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