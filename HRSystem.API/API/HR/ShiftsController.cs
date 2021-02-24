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
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly ILogger<ShiftsController> _logger;

        public ShiftsController(IShiftRepository shiftRepository,
                                ILogger<ShiftsController> logger)
        {
            _shiftRepository = shiftRepository;
            _logger = logger;
        }

        // GET: api/<ShiftsController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Shift>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var shifts = await _shiftRepository.GetAll(queryParameters);


                return Ok(shifts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<ShiftsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shift>> Get(int id)
        {
            try
            {
                var shift = await _shiftRepository.GetById(id);

                return Ok(shift);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        // POST api/<ShiftsController>
        [HttpPost]
        public async Task<ActionResult<Shift>> Post(Shift shift)
        {
            try
            {
                _shiftRepository.Create(shift);
                await _shiftRepository.SaveChanges();

                return Ok(shift);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<ShiftsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Shift>> Put(int id, Shift shift)
        {
            try
            {
                _shiftRepository.Update(id, shift);
                await _shiftRepository.SaveChanges();

                return Ok(shift);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<ShiftsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shiftRepository.Remove(id);
                await _shiftRepository.SaveChanges();

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