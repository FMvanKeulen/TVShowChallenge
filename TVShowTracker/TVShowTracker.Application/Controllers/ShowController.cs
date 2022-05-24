using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Application.DTOs;
using TVShowTracker.Application.Interfaces;

namespace TVShowTracker.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _service;

        public ShowController(IShowService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowDTO>>> GetAll()
        {
            var shows = await _service.GetShowsAsync();
            return Ok(shows);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ShowDTO>> GetById(int id)
        {
            var show = await _service.GetByIdAsync(id);
            return Ok(show);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreateAsync([FromBody] ShowDTO showDTO)
        {
            await _service.AddAsync(showDTO);
            return Created(nameof(CreateAsync), showDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int? id, [FromBody] ShowDTO showDTO)
        {
            if (id == null)
                return NotFound();

            if(showDTO.Id != id)
                return BadRequest();
            
            await _service.UpdateAsync(showDTO);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id == null)
                return NotFound();

            await _service.RemoveAsync(id);

            return Accepted();
        }
    }
}