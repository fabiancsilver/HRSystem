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
    public class PositionsController : ControllerBase
    {
        private readonly IPositionRepository _positionRepository;
        private readonly ILogger<PositionsController> _logger;

        public PositionsController(IPositionRepository positionRepository,
                                ILogger<PositionsController> logger)
        {
            _positionRepository = positionRepository;
            _logger = logger;
        }

        // GET: api/<PositionsController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Position>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var positions = await _positionRepository.GetAll(queryParameters);


                return Ok(positions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<PositionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> Get(int id)
        {
            try
            {
                var position = await _positionRepository.GetById(id);

                return Ok(position);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        // POST api/<PositionsController>
        [HttpPost]
        public async Task<ActionResult<Position>> Post(Position position)
        {
            try
            {
                _positionRepository.Create(position);
                await _positionRepository.SaveChanges();

                return Ok(position);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<PositionsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Position>> Put(int id, Position position)
        {
            try
            {
                _positionRepository.Update(id, position);
                await _positionRepository.SaveChanges();

                return Ok(position);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<PositionsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _positionRepository.Remove(id);
                await _positionRepository.SaveChanges();

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