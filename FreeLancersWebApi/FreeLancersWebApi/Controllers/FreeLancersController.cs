using FreeLancersWebApi.Modells;
using FreeLancersWebApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreeLancersWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreeLancersController : ControllerBase
    {
        private readonly FreeLancerService _freeLancerService;

        public FreeLancersController(FreeLancerService freeLancerService) =>
            _freeLancerService = freeLancerService;

        // GET: api/<FreeLancerController>
        [HttpGet]
        public async Task<ActionResult<List<FreeLancer>>> Get() =>
            await _freeLancerService.Get();


        // GET api/<FreeLancerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FreeLancer>> Get(Guid id)
        {
            var freeLancer = await _freeLancerService.Get(id);
            return freeLancer is null ? NotFound($"Freelancer wit Id = {id} not found") : Ok(freeLancer);
        }

        // POST api/<FreeLancerController>
        [HttpPost]
        public async Task<ActionResult<FreeLancer>> Post([FromBody] FreeLancer freeLancer)
        {
            await _freeLancerService.Create(freeLancer);
            return CreatedAtAction(nameof(Get), new { id = freeLancer.id }, freeLancer);
            //return Ok();
        }

        // PUT api/<FreeLancerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] FreeLancer updateFreeLancer)
        {
            var existingFreeLancer = await _freeLancerService.Get(id);
            if (existingFreeLancer is null) return NotFound($"Freelancer wit Id = {id} not found");

            updateFreeLancer.id = existingFreeLancer.id;
            await _freeLancerService.Update(id, updateFreeLancer);
            return NoContent();
        }

        // DELETE api/<FreeLancerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var existingFreeLancer = await _freeLancerService.Get(id);
            if (existingFreeLancer is null) return NotFound($"Freelancer wit Id = {id} not found");

            
            await _freeLancerService.Remove(existingFreeLancer.id);
            return Ok($"FreeLancer with Id= {id} deleted.");
        }
    }
}
