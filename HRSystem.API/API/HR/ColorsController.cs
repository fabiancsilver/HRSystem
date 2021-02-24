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
    public class ColorsController : ControllerBase
    {
        private readonly IColorRepository _colorRepository;
        private readonly ILogger<ColorsController> _logger;

        public ColorsController(IColorRepository colorRepository,
                                ILogger<ColorsController> logger)
        {
            _colorRepository = colorRepository;
            _logger = logger;
        }

        // GET: api/<ColorsController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Color>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var colors = await _colorRepository.GetAll(queryParameters);


                return Ok(colors);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<ColorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> Get(int id)
        {
            try
            {
                var color = await _colorRepository.GetById(id);

                return Ok(color);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        // POST api/<ColorsController>
        [HttpPost]
        public async Task<ActionResult<Color>> Post(Color color)
        {
            try
            {
                _colorRepository.Create(color);
                await _colorRepository.SaveChanges();

                return Ok(color);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<ColorsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Color>> Put(int id, Color color)
        {
            try
            {
                _colorRepository.Update(id, color);
                await _colorRepository.SaveChanges();

                return Ok(color);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<ColorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _colorRepository.Remove(id);
                await _colorRepository.SaveChanges();

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