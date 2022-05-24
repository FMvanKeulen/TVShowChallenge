using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVShowTracker.Application.DTOs;
using TVShowTracker.Application.Interfaces;
using TVShowTracker.Domain.Entities;

namespace TVShowTracker.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _service;

        public ActorController(IActorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetAll()
        {
            var actors = await _service.GetActorsAsync();
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetById(int id)
        {
            var actor = await _service.GetByIdAsync(id);

            if (actor == null)
                return NotFound();

            return Ok(actor);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] ActorDTO actorDTO)
        {
            await _service.AddAsync(actorDTO);
            return Created(nameof(CreateAsync), actorDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int? id, [FromBody] ActorDTO actorDTO)
        {
            if (id == null)
                return NotFound();

            if (actorDTO.Id != id)
                return BadRequest();

            await _service.UpdateAsync(actorDTO);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            await _service.RemoveAsync(id);
            return Accepted();
        }
    }
}